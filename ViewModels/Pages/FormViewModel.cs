using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using DdApp.Models;
using Microsoft.EntityFrameworkCore;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace Skalalazy.ViewModels.Pages;

public abstract partial class FormViewModel<TEntity>(ClimbersDbContext dbContext)
    : ObservableObject, INavigationAware where TEntity : class
{
    #region Properies

    protected ClimbersDbContext DbContext { get; } = dbContext;

    [ObservableProperty] private int _index;

    [ObservableProperty] private bool _saving;

    [ObservableProperty] private ObservableCollection<Item<TEntity>> _itemsList = [];

    [ObservableProperty] private Item<TEntity>? _selectedItem;

    [ObservableProperty] private bool _isNewItem;

    [ObservableProperty] private bool _isCreateForm;

    [ObservableProperty] private bool _isUpdated;

    [ObservableProperty] private bool _isDeleteItem;

    #endregion

    #region Value chages triggres

    partial void OnIndexChanged(int oldValue, int newValue)
    {
        SaveCurrentForm(oldValue);
        SelectedItem = ItemsList.ElementAtOrDefault(Index);
        IsCreateForm = newValue == -1;
    }

    partial void OnItemsListChanged(ObservableCollection<Item<TEntity>> value)
    {
        Index = Math.Min(Index, value.Count - 1);
        SelectedItem = ItemsList.ElementAtOrDefault(Index);
    }

    partial void OnSelectedItemChanged(Item<TEntity>? value)
    {
        if (value != null)
        {
            IsNewItem = value.Created;
            IsDeleteItem = value.Deleted;
            IsUpdated = value.Updated;
            SetFormFromItem(value);
        }
        else
            SetFormNull();
    }

    #endregion

    #region Commands

    [RelayCommand]
    private void Add()
    {
        ItemsList.Add(new Item<TEntity>(CreateItemFromForm(), true));
        Index = ItemsList.Count - 1;
        
    }

    [RelayCommand]
    private void Delete()
    {
        IsDeleteItem = !IsDeleteItem;
    }

    [RelayCommand]
    private void Save()
    {
        Saving = true;
        SaveCurrentForm(Index);

        var createdItems = ItemsList.Where(item => !item.Deleted && item.Created).Select(item => item.Value)
            .ToList();

        var deletedItems = ItemsList.Where(item => item.Deleted && !item.Created).Select(item => item.Value)
            .ToList();

        var updatedItems = ItemsList.Where(item => !item.Deleted && !item.Created)
            .Select(item => item.Value)
            .ToList();

        try
        {
            DbContext.Set<TEntity>().AddRange(createdItems);
            DbContext.Set<TEntity>().RemoveRange(deletedItems);
            DbContext.Set<TEntity>().UpdateRange(updatedItems);
            DbContext.SaveChanges();
            
       
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
      
        }
        

        Update();
        Saving = false;
    }

    [RelayCommand]
    private void IncreaseIndex()
    {
        Index = Math.Min(Index + 1, ItemsList.Count - 1);
    }

    [RelayCommand]
    private void DecreaseIndex()
    {
        Index = Math.Max(Index - 1, 0);
    }

    [RelayCommand]
    private void FirstIndex()
    {
        Index = Math.Min(ItemsList.Count, 1) - 1;
    }

    [RelayCommand]
    private void LastIndex()
    {
        Index = ItemsList.Count - 1;
    }

    [RelayCommand]
    private void Create()
    {
        Index = -1;
    }

    [RelayCommand]
    protected virtual void Update()
    {
        ItemsList = DbContext.Set<TEntity>().Select((entity) => new Item<TEntity>(entity, false))
            .ToObservableCollection();
    }

    #endregion

    #region App Navigation

    public virtual void OnNavigatedTo()
    {
        Update();
    }

    public virtual void OnNavigatedFrom()
    {
    }

    #endregion

    #region Work with Form

    private void SaveCurrentForm(int index)
    {
        var item = ItemsList.ElementAtOrDefault(index);
        if (item == null) return;
        item.Deleted = IsDeleteItem;
        item.Created = IsNewItem;
        item.Updated = IsUpdated;
        SetItemFromForm(item);
    }

    protected abstract void SetItemFromForm(Item<TEntity> item);

    protected abstract void SetFormFromItem(Item<TEntity> item);

    protected abstract void SetFormNull();

    protected abstract TEntity CreateItemFromForm();

    #endregion
}
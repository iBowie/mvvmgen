﻿using MvvmGen;
using MvvmGen.Events;
using Sample.WpfApp.DataProvider;
using Sample.WpfApp.Events;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sample.WpfApp.ViewModel
{
  [ViewModel]
  partial class NavigationViewModel : IEventSubscriber<EmployeeSavedEvent>
  {
    [Property]
    private NavigationViewModel? _selectedItem;
    private IEventAggregator _eventAggregator;

    public NavigationViewModel(IEventAggregator eventAggregator,
      IEmployeeDataProvider dataProvider)
    {
      _eventAggregator = eventAggregator;
    }

    public void OnEvent(EmployeeSavedEvent eventData)
    {
      var item = Items.SingleOrDefault(x => x.Id == eventData.EmployeeId);
      if (item == null)
      {
        Items.Add(new NavigationItemViewModel { Id = eventData.EmployeeId, FirstName = eventData.FirstName });
      }
      else
      {
        item.FirstName = eventData.FirstName;
      }
    }

    public ObservableCollection<NavigationItemViewModel> Items { get; } = new();
  }

  [ViewModel]
  partial class NavigationItemViewModel
  {
    [Property] int _id;
    [Property] string _firstName;
  }
}
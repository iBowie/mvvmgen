﻿// ***********************************************************************
// ⚡ MvvmGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using Xunit;

namespace MvvmGen.SourceGenerators
{
    public partial class InjectAttributeTests : ViewModelGeneratorTestsBase
    {
        [InlineData("empDbProvider", "EmpDbProvider", ", PropertyName=\"EmpDbProvider\"")]
        [InlineData("empDbProvider", "EmpDbProvider", ", \"EmpDbProvider\"")]
        [InlineData("employeeDataProvider", "EmployeeDataProvider", "")]
        [Theory]
        public void GeneratePropertyOfInjectedType(string expectedConstructorParameterName, string expectedPropertyName, string attributeArgument)
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  public interface IEmployeeDataProvider {{}}

  [Inject(typeof(IEmployeeDataProvider){attributeArgument}))]
  [ViewModel]
  public partial class EmployeeViewModel
  {{
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel(MyCode.IEmployeeDataProvider {expectedConstructorParameterName})
        {{
            this.{expectedPropertyName} = {expectedConstructorParameterName};
            this.OnInitialize();
        }}

        partial void OnInitialize();

        protected MyCode.IEmployeeDataProvider {expectedPropertyName} {{ get; private set; }}
    }}
}}
");
        }

        [InlineData("private", "AccessModifier.Private")]
        [InlineData("protected internal", "AccessModifier.ProtectedInternal")]
        [InlineData("protected", "AccessModifier.Protected")]
        [InlineData("internal", "AccessModifier.Internal")]
        [InlineData("public", "AccessModifier.Public")]
        [InlineData("protected", "")]
        [Theory]
        public void GeneratePropertyWithSpecifiedAccessModifier(string expectedAccessModifier, string attributeAccessModifier)
        {
            var namedArgumentForAttribute = "";
            if (attributeAccessModifier is { Length: > 0 })
            {
                namedArgumentForAttribute = $",PropertyAccessModifier = {attributeAccessModifier}";
            }

            var expectedSetterAccessModifier = expectedAccessModifier == "private" ? "" : "private";

            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  public interface INavigationViewModel {{}}

  [Inject(typeof(INavigationViewModel){namedArgumentForAttribute})]
  [ViewModel]
  public partial class EmployeeViewModel
  {{
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel(MyCode.INavigationViewModel navigationViewModel)
        {{
            this.NavigationViewModel = navigationViewModel;
            this.OnInitialize();
        }}

        partial void OnInitialize();

        {expectedAccessModifier} MyCode.INavigationViewModel NavigationViewModel {{ get; {expectedSetterAccessModifier} set; }}
    }}
}}
");
        }

        [Fact]
        public void GeneratePropertyOfInjectedType2()
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  [Inject(typeof(MvvmGen.Events.IEventAggregator)))]
  [ViewModel]
  public partial class EmployeeViewModel
  {{
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel(MvvmGen.Events.IEventAggregator eventAggregator)
        {{
            this.EventAggregator = eventAggregator;
            this.OnInitialize();
        }}

        partial void OnInitialize();

        protected MvvmGen.Events.IEventAggregator EventAggregator {{ get; private set; }}
    }}
}}
");
        }


        [Fact]
        public void GenerateConstructorAndPropertiesInOrderOfInjectAttributesBottomUp()
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  public interface IEventAggregator {{}}
  public interface IEmployeeDataProvider {{}}
  public interface IDialogService {{}}


  [Inject(typeof(IDialogService))]
  [Inject(typeof(IEmployeeDataProvider))]
  [Inject(typeof(IEventAggregator))]
  [ViewModel]
  public partial class EmployeeViewModel
  {{
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel(MyCode.IEventAggregator eventAggregator, MyCode.IEmployeeDataProvider employeeDataProvider, MyCode.IDialogService dialogService)
        {{
            this.EventAggregator = eventAggregator;
            this.EmployeeDataProvider = employeeDataProvider;
            this.DialogService = dialogService;
            this.OnInitialize();
        }}

        partial void OnInitialize();

        protected MyCode.IEventAggregator EventAggregator {{ get; private set; }}

        protected MyCode.IEmployeeDataProvider EmployeeDataProvider {{ get; private set; }}

        protected MyCode.IDialogService DialogService {{ get; private set; }}
    }}
}}
");
        }

        [Fact]
        public void GeneratePropertyForInjectedGenericInterface()
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  public interface ILogger<T> {{}}

  [Inject(typeof(ILogger<EmployeeViewModel>))]
  [ViewModel]
  public partial class EmployeeViewModel
  {{
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel(MyCode.ILogger<MyCode.EmployeeViewModel> logger)
        {{
            this.Logger = logger;
            this.OnInitialize();
        }}

        partial void OnInitialize();

        protected MyCode.ILogger<MyCode.EmployeeViewModel> Logger {{ get; private set; }}
    }}
}}
");
        }

        [Fact]
        public void GeneratePropertiesForMultipleInjectedGenericInterfacesOfSameType()
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  public interface IDataProvider<T> {{}}
  public class Customer {{}}
  public class Order {{}}

  [Inject(typeof(IDataProvider<Order>))]
  [Inject(typeof(IDataProvider<Customer>))]
  [ViewModel]
  public partial class EmployeeViewModel
  {{
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel(MyCode.IDataProvider<MyCode.Customer> dataProvider1, MyCode.IDataProvider<MyCode.Order> dataProvider2)
        {{
            this.DataProvider1 = dataProvider1;
            this.DataProvider2 = dataProvider2;
            this.OnInitialize();
        }}

        partial void OnInitialize();

        protected MyCode.IDataProvider<MyCode.Customer> DataProvider1 {{ get; private set; }}

        protected MyCode.IDataProvider<MyCode.Order> DataProvider2 {{ get; private set; }}
    }}
}}
");
        }
    }
}

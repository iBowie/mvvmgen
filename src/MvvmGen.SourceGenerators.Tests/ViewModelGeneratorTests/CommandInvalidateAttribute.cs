﻿// ***********************************************************************
// ⚡ MvvmGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using Xunit;

namespace MvvmGen.SourceGenerators
{
    public class CommandInvalidateAttributeTests : ViewModelGeneratorTestsBase
    {
        [InlineData(true, true, false, "[CommandInvalidate(nameof(FirstName),nameof(LastName))]")]
        [InlineData(true, true, false, "[CommandInvalidate(\"FirstName\",\"LastName\")]")]
        [InlineData(true, true, false, "[CommandInvalidate(\"FirstName\",new string[]{\"LastName\"})]")]
        [InlineData(true, true, false, "[CommandInvalidate(\"FirstName\",new[]{\"LastName\"})]")]
        [InlineData(true, true, false, "[CommandInvalidate(\"FirstName\",new string[]{nameof(LastName)})]")]
        [InlineData(true, true, false, "[CommandInvalidate(\"FirstName\",new[]{nameof(LastName)})]")]
        [InlineData(true, true, false, "[CommandInvalidate(nameof(FirstName))]\r\n[CommandInvalidate(nameof(LastName))]")]
        [InlineData(true, true, false, "[CommandInvalidate(\"FirstName\")]\r\n[CommandInvalidate(\"LastName\"))]")]
        [InlineData(true, false, false, "[CommandInvalidate(nameof(FirstName))]")]
        [InlineData(true, false, false, "[CommandInvalidate(\"FirstName\")]")]
        [InlineData(true, false, true, "[CommandInvalidate(nameof(FirstName))]")]
        [InlineData(true, false, true, "[CommandInvalidate(\"FirstName\")]")]
        [Theory]
        public void RaiseCanExecuteChangedInFirstNameProperty(
            bool isCallInFirstNamePropExpected,
            bool isCallInLastNamePropExpected,
            bool putAttributeOnExecuteMethod,
            string commandInvalidateAttribute)
        {
            var expectedIfElseBlock = "";

            if (isCallInFirstNamePropExpected && isCallInLastNamePropExpected)
            {
                expectedIfElseBlock = 
                $@"if (propertyName == ""FirstName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
            }}
            else if (propertyName == ""LastName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
            }}";
            }
            else if (isCallInFirstNamePropExpected)
            {
                expectedIfElseBlock =
               $@"if (propertyName == ""FirstName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
            }}";
            }
            else if (isCallInLastNamePropExpected)
            {
                expectedIfElseBlock =
               $@"if (propertyName == ""LastName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
            }}";
            }

            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  [ViewModel]
  public partial class EmployeeViewModel
  {{
    [Property] string _firstName;
    [Property] string _lastName;
    
    {(putAttributeOnExecuteMethod ? commandInvalidateAttribute : "")}
    [Command(nameof(CanSave))]
    public void Save() {{ }}

    {(putAttributeOnExecuteMethod ? "" : commandInvalidateAttribute)}
    public bool CanSave() => true;
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel()
        {{
            this.InitializeCommands();
            this.OnInitialize();
        }}

        partial void OnInitialize();

        private void InitializeCommands()
        {{
            SaveCommand = new DelegateCommand(_ => Save(), _ => CanSave());
        }}

        public DelegateCommand SaveCommand {{ get; private set; }}

        public string FirstName
        {{
            get => _firstName;
            set
            {{
                if (_firstName != value)
                {{
                    _firstName = value;
                    OnPropertyChanged(""FirstName"");
                }}
            }}
        }}

        public string LastName
        {{
            get => _lastName;
            set
            {{
                if (_lastName != value)
                {{
                    _lastName = value;
                    OnPropertyChanged(""LastName"");
                }}
            }}
        }}

        protected override void InvalidateCommands(string? propertyName)
        {{
            base.InvalidateCommands(propertyName);
            {expectedIfElseBlock}
        }}
    }}
}}
");
        }

        [Fact]
        public void RaiseCanExecuteChangedForMultipleCommandProperties()
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  [ViewModel]
  public partial class EmployeeViewModel
  {{
    [Property] string _firstName;
    [Property] string _lastName;
    
    [Command(nameof(CanSave))]
    public void Save() {{ }}

    [CommandInvalidate(nameof(FirstName);
    [CommandInvalidate(nameof(LastName);
    public bool CanSave() => true;

    [Command(nameof(CanDelete))]
    public void Delete() {{ }}

    [CommandInvalidate(nameof(FirstName);
    public bool CanDelete() => true;
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel()
        {{
            this.InitializeCommands();
            this.OnInitialize();
        }}

        partial void OnInitialize();

        private void InitializeCommands()
        {{
            SaveCommand = new DelegateCommand(_ => Save(), _ => CanSave());
            DeleteCommand = new DelegateCommand(_ => Delete(), _ => CanDelete());
        }}

        public DelegateCommand SaveCommand {{ get; private set; }}

        public DelegateCommand DeleteCommand {{ get; private set; }}

        public string FirstName
        {{
            get => _firstName;
            set
            {{
                if (_firstName != value)
                {{
                    _firstName = value;
                    OnPropertyChanged(""FirstName"");
                }}
            }}
        }}

        public string LastName
        {{
            get => _lastName;
            set
            {{
                if (_lastName != value)
                {{
                    _lastName = value;
                    OnPropertyChanged(""LastName"");
                }}
            }}
        }}

        protected override void InvalidateCommands(string? propertyName)
        {{
            base.InvalidateCommands(propertyName);
            if (propertyName == ""FirstName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }}
            else if (propertyName == ""LastName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
            }}
        }}
    }}
}}
");
        }

        [Fact]
        public void RaiseCanExecuteChangedForBaseClassProperties()
        {
            ShouldGenerateExpectedCode(
      $@"using MvvmGen;

namespace MyCode
{{
  [ViewModel]
  public partial class EmployeeViewModelBase
  {{
    [Property] string _firstName;
  }}
  
  [ViewModel]
  public partial class EmployeeViewModel
  {{
    [Command(nameof(CanSave))]
    public void Save() {{ }}

    [CommandInvalidate(nameof(FirstName);
    public bool CanSave() => true;
  }}
}}",
      $@"{AutoGeneratedTopContent}

namespace MyCode
{{
    partial class EmployeeViewModel : global::MvvmGen.ViewModels.ViewModelBase
    {{
        public EmployeeViewModel()
        {{
            this.InitializeCommands();
            this.OnInitialize();
        }}

        partial void OnInitialize();

        private void InitializeCommands()
        {{
            SaveCommand = new DelegateCommand(_ => Save(), _ => CanSave());
        }}

        public DelegateCommand SaveCommand {{ get; private set; }}

        protected override void InvalidateCommands(string? propertyName)
        {{
            base.InvalidateCommands(propertyName);
            if (propertyName == ""FirstName"")
            {{
                SaveCommand.RaiseCanExecuteChanged();
            }}
        }}
    }}
}}
");
        }
    }
}

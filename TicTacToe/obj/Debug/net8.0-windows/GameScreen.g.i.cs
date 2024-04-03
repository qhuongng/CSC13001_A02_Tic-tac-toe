﻿#pragma checksum "..\..\..\GameScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D10CFF54729F7064B6A255337CD06D9F122A432"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TicTacToe;


namespace TicTacToe {
    
    
    /// <summary>
    /// GameScreen
    /// </summary>
    public partial class GameScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CurrentPlayer;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HelpBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MusicBtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MusicIcon;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SoundBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SoundIcon;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SaveIcon;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RestartBtn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\GameScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameCanvas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TicTacToe;component/gamescreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GameScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\GameScreen.xaml"
            ((TicTacToe.GameScreen)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Canvas_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\GameScreen.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CurrentPlayer = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.HelpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\GameScreen.xaml"
            this.HelpBtn.Click += new System.Windows.RoutedEventHandler(this.HelpBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MusicBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\GameScreen.xaml"
            this.MusicBtn.Click += new System.Windows.RoutedEventHandler(this.MusicBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MusicIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.SoundBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\GameScreen.xaml"
            this.SoundBtn.Click += new System.Windows.RoutedEventHandler(this.SoundBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SoundIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\GameScreen.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SaveIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.RestartBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\GameScreen.xaml"
            this.RestartBtn.Click += new System.Windows.RoutedEventHandler(this.ResetGame);
            
            #line default
            #line hidden
            return;
            case 12:
            this.GameCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 63 "..\..\..\GameScreen.xaml"
            this.GameCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

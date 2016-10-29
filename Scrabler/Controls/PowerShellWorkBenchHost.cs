using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Diagnostics;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Management.Automation.Host;
using System.Management.Automation.Provider;
namespace Scrabler.Controls
{

    public class PowerShellWorkBenchHost : System.Management.Automation.Host.PSHost
    {
        private Guid _instanceID = new Guid("eb30b404-18c2-455d-8271-423039280b9b");
        private PowerShellWorkBenchHostUI _UI = new PowerShellWorkBenchHostUI();
        public override string Name
        {
            get { return "PowerShellWorkBenchHost"; }
        }

        public override Version Version
        {
            get { return new Version(1, 0, 0); }
        }

        public override Guid InstanceId
        {
            get { return _instanceID; }
        }

        public override System.Management.Automation.Host.PSHostUserInterface UI
        {
            get { return _UI; }
        }

        public override System.Globalization.CultureInfo CurrentCulture
        {
            get { return System.Threading.Thread.CurrentThread.CurrentCulture; }
        }

        public override System.Globalization.CultureInfo CurrentUICulture
        {
            get { return System.Threading.Thread.CurrentThread.CurrentUICulture; }
        }

        public override void SetShouldExit(int exitCode)
        {
           // throw new NotImplementedException();
        }

        public override void EnterNestedPrompt()
        {
           // throw new NotImplementedException();
        }

        public override void ExitNestedPrompt()
        {
           // throw new NotImplementedException();
        }

        public override void NotifyBeginApplication()
        {
           // throw new NotImplementedException();
        }

        public override void NotifyEndApplication()
        {
           // throw new NotImplementedException();
        }

    }


    public class PowerShellWorkBenchHostUI : System.Management.Automation.Host.PSHostUserInterface
    {
        private PowerShellWorkBenchHostRawUI _RawUI = new PowerShellWorkBenchHostRawUI();
        public override System.Management.Automation.Host.PSHostRawUserInterface RawUI
        {
            get { return _RawUI; }
        }

        public override string ReadLine()
        {
           // throw new NotImplementedException();'
            return null;
           
        }

        public override System.Security.SecureString ReadLineAsSecureString()
        {
            return null;
           // throw new NotImplementedException();
        }

        public override void Write(string value)
        {
            if (value == Environment.NewLine)
            {
                //UIEvents.Add(new UIAction("Write", Constants.vbCrLf));
            }
            else
            {
                //UIEvents.Add(new UIAction("Write", value));
            }
        }

        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            //UIEvents.Add(new UIAction("Write", value));
        }

        public override void WriteLine(string value)
        {
            //UIEvents.Add(new UIAction("Write", value + Constants.vbCrLf));
        }

        public override void WriteErrorLine(string value)
        {
            //UIEvents.Add(new UIAction("Write", "ERROR:" + value + Constants.vbCrLf));
        }

        public override void WriteDebugLine(string message)
        {
            //UIEvents.Add(new UIAction("Write", "DEBUG:" + message + Constants.vbCrLf));
        }

        public override void WriteProgress(long sourceId, System.Management.Automation.ProgressRecord record)
        {
           // throw new NotImplementedException();
        }

        public override void WriteVerboseLine(string message)
        {
            //UIEvents.Add(new UIAction("Write", "VERBOSE:" + message + Constants.vbCrLf));
        }

        public override void WriteWarningLine(string message)
        {
            //////UIEvents.Add(new UIAction("Write", "WARNING:" + message + Constants.vbCrLf));
        }

        public override Dictionary<string, System.Management.Automation.PSObject> Prompt(string caption, string message, System.Collections.ObjectModel.Collection<System.Management.Automation.Host.FieldDescription> descriptions)
        {
           // throw new NotImplementedException();
        }

        public override System.Management.Automation.PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
           // throw new NotImplementedException();
        }

        public override System.Management.Automation.PSCredential PromptForCredential(string caption, string message, string userName, string targetName, System.Management.Automation.PSCredentialTypes allowedCredentialTypes, System.Management.Automation.PSCredentialUIOptions options)
        {
           // throw new NotImplementedException();
        }

        public override int PromptForChoice(string caption, string message, System.Collections.ObjectModel.Collection<System.Management.Automation.Host.ChoiceDescription> choices, int defaultChoice)
        {
           // throw new NotImplementedException();
        }

    }

    public class PowerShellWorkBenchHostRawUI : System.Management.Automation.Host.PSHostRawUserInterface
    {

        public override ConsoleColor ForegroundColor
        {
            get { return ConsoleColor.Black; }
           
        }

        public override ConsoleColor BackgroundColor
        {
            get { return ConsoleColor.White; }
          
        }

        public override System.Management.Automation.Host.Coordinates CursorPosition
        {
            get
            {
               // throw new NotImplementedException();
                return new Coordinates();
            }
         
        }

        public override System.Management.Automation.Host.Coordinates WindowPosition
        {
            get
            {
               // throw new NotImplementedException();
                return new Coordinates();
            }
           
        }

        public override int CursorSize
        {
            get
            {
               // throw new NotImplementedException();
                return 0;
            }
           
        }

        public override System.Management.Automation.Host.Size BufferSize
        {
            get { return new System.Management.Automation.Host.Size(80, 80); }
            
        }

        public override System.Management.Automation.Host.Size WindowSize
        {
            get { return new System.Management.Automation.Host.Size(); }
            
        }

        public override System.Management.Automation.Host.Size MaxWindowSize
        {
            get { return new System.Management.Automation.Host.Size(); }
            
        }

        public override System.Management.Automation.Host.Size MaxPhysicalWindowSize
        {
            get { return new System.Management.Automation.Host.Size(); }
            
        }

        public override bool KeyAvailable
        {
            get { return true; }
        }

        public override string WindowTitle
        {
            get
            {
                return null;
               // throw new NotImplementedException();
            }
           
        }

        public override System.Management.Automation.Host.KeyInfo ReadKey(System.Management.Automation.Host.ReadKeyOptions options)
        {
           // throw new NotImplementedException();
        }

        public override void FlushInputBuffer()
        {
           
           // throw new NotImplementedException();
        }

        public override void SetBufferContents(System.Management.Automation.Host.Coordinates origin, System.Management.Automation.Host.BufferCell[,] contents)
        {
            return null;
           // throw new NotImplementedException();
        }

        public override void SetBufferContents(System.Management.Automation.Host.Rectangle rectangle, System.Management.Automation.Host.BufferCell fill)
        {
           // throw new NotImplementedException();
            return null;
        }

        public override System.Management.Automation.Host.BufferCell[,] GetBufferContents(System.Management.Automation.Host.Rectangle rectangle)
        {
           // throw new NotImplementedException();
            return null;
        }

        public override void ScrollBufferContents(System.Management.Automation.Host.Rectangle source, System.Management.Automation.Host.Coordinates destination, System.Management.Automation.Host.Rectangle clip, System.Management.Automation.Host.BufferCell fill)
        {
           // throw new NotImplementedException();
        }

    }

public static class PWBUIHandling
{
	private static Dictionary<string, object> Menus = new Dictionary<string, object>();
	private static int menuVersion = 0;
	public static Dictionary<string, TreeView> Trees = new Dictionary<string, TreeView>();

}

	
	public class UIAction
	{
		public System.DateTime ActionDateTime;
		public int UIActionID;
		public string ActionType;
		public string Message;
		public object Tag;
		public Color ForegroundColor;
		public Color BackgroundColor;
		public System.Collections.Specialized.StringDictionary strings = new System.Collections.Specialized.StringDictionary();
		public Dictionary<string, object> objects = new Dictionary<string, object>();
		public UIAction(string strActionType, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute("")]  // ERROR: Optional parameters aren't supported in C#
string strMessage)
		{
			ActionType = strActionType;
			Message = strMessage;
		}
	

	public static List <UIAction> UIEvents = new List<UIAction>();
	public static void ProcessEvents()
	{
		//blnScrollPending = false;
		while (UIEvents.Count > 0) {
			//ProcessEvent(UIEvents[0]);
			UIEvents.RemoveAt(0);
		}
		
	}
	/*private static void ProcessEvent(UIAction act)
	{
		switch (act.ActionType) {
			case "Write":
				WorkBench.OutputBox.AppendText(act.Message);
				blnScrollPending = true;
				break;
			case "ClearHost":
				WorkBench.OutputBox.Clear();
				break;
			case "NewTree":
				NewTree(act);
				break;
			case "NewTreeNode":
				TreeView t = default(TreeView);
				TreeViewItem _node = new TreeViewItem();
				string strTreeName = act.strings("TreeName");
				string strParentName = act.strings("ParentName");
				PSObject oParent = act.objects("ParentObject");
				PSObject oNode = act.objects("NodeObject");
				_node.Header = act.strings("NodeName");
				_node.Tag = oNode;
				try {
					t = Trees(strTreeName);
				} catch (Exception ex) {
					NewTree(new UIAction("NewTree", strTreeName));
					t = Trees(strTreeName);
				}
				TreeViewItem _parent = FindNodeInTree(strParentName, t.Items, oParent);
				if (_parent == null) {
					if (!string.IsNullOrEmpty(strParentName)) {
						_parent = new TreeViewItem();
						_parent.Header = strParentName;
						t.Items.Add(_parent);
						_parent.Items.Add(_node);
					} else {
						t.Items.Add(_node);
					}
				} else {
					_parent.Items.Add(_node);
				}
				break;
			case "ClearTree":
				TreeView t = default(TreeView);
				string strTreeName = act.Message;

				try {
					t = Trees(strTreeName);
					t.Items.Clear();

				} catch (Exception ex) {
				}
				break;
			case "RemoveTree":
				TreeView t = default(TreeView);
				string strTreeName = act.Message;

				try {
					AvalonDock.DocumentPane oLeftPanel = default(AvalonDock.DocumentPane);
					t = Trees(strTreeName);
					Trees.Remove(strTreeName);
					AvalonDock.DockableContent d = default(AvalonDock.DockableContent);
					d = t.Parent;
					oLeftPanel = WorkBench.LeftRightPanel.Children(0);
					oLeftPanel.Items.Remove(d);
					if (oLeftPanel.Items.Count == 0) {
						WorkBench.LeftRightPanel.Children.Remove(oLeftPanel);

					}

				} catch (Exception ex) {
				}
				break;
			case "NewTypeMenuItem":
				string _typename = act.Message;
				object _action = act.objects("Action");
				string _name = act.strings("Name").Replace("_", " ");
				ContextMenu cntTypeMenu = default(ContextMenu);
				if (Menus.ContainsKey(_typename)) {
					cntTypeMenu = Menus(_typename);
				} else {
					cntTypeMenu = new ContextMenu();
					Menus(_typename) = cntTypeMenu;
				}
				MenuItem mi = new MenuItem();
				mi.Header = _name;
				if ((_action) is string) {
					mi.Tag = _action;
				} else if ((_action) is Collections.Hashtable) {
					Hashtable d = _action;
					MenuItem submenu = default(MenuItem);
					foreach (string k in d.Keys) {
						submenu = new MenuItem();
						submenu.Header = k.Replace("_", " ");
						submenu.Tag = d[k];
						mi.Items.Add(submenu);
					}

				}
				cntTypeMenu.Items.Add(mi);
				menuVersion += 1;
				break;
			default:

				break;
		}
	}
	*/

	/*public static void NewTree(UIAction act)
	{
		AvalonDock.DocumentPane oLeftPanel = default(AvalonDock.DocumentPane);
		TreeView t = new TreeView();
		t.MouseDoubleClick += TreeView1_MouseDoubleClick;
		t.PreviewMouseRightButtonDown += TreeView_MouseRightClick;
		if (Trees.ContainsKey(act.Message))
			return;
		Trees.Add(act.Message, t);
		if (WorkBench.LeftRightPanel.Children.Count == 1) {
			oLeftPanel = new AvalonDock.DocumentPane();
			WorkBench.LeftRightPanel.Children.Insert(0, oLeftPanel);
		} else {
			oLeftPanel = WorkBench.LeftRightPanel.Children(0);
		}
		AvalonDock.DockableContent d = new AvalonDock.DockableContent();
		d.Content = t;
		d.Title = act.Message;
		t.HorizontalAlignment = HorizontalAlignment.Stretch;
		t.VerticalAlignment = VerticalAlignment.Stretch;
		oLeftPanel.Items.Add(d);
		d.IsVisibleChanged += DockableContent_IsVisibleChanged;
		oLeftPanel.SelectedItem = d;

	}
        */
	
	
	
}



}

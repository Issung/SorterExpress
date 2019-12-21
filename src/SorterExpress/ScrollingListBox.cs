using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SorterExpress
{
	/// <summary>
	/// Summary description for ScrollingListBox.
	/// </summary>
	public class ScrollingListBox : System.Windows.Forms.ListBox
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		[Category("Action")]
		public event ScrollEventHandler Scrolled = null;

		private const int WM_HSCROLL = 0x114;
		private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x020A;

        private const int SB_LINELEFT = 0;
		private const int SB_LINERIGHT = 1;
		private const int SB_PAGELEFT = 2;
		private const int SB_PAGERIGHT = 3;
		private const int SB_THUMBPOSITION = 4;
		private const int SB_THUMBTRACK = 5;
		private const int SB_LEFT = 6;
		private const int SB_RIGHT = 7;
		private const int SB_ENDSCROLL = 8;

		private const int SIF_TRACKPOS = 0x10;
		private const int SIF_RANGE = 0x1;
		private const int SIF_POS = 0x4;
		private const int SIF_PAGE = 0x2;
		private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

		[DllImport("user32.dll", SetLastError=true) ]
		private static extern int GetScrollInfo( IntPtr hWnd, int n, ref ScrollInfoStruct lpScrollInfo );

		private struct ScrollInfoStruct
		{
			public int cbSize;
			public int fMask;
			public int nMin;
			public int nMax;
			public int nPage;
			public int nPos;
			public int nTrackPos;
		}

		protected override void WndProc(ref System.Windows.Forms.Message msg)
		{
			//if( msg.Msg == WM_HSCROLL )
            if (msg.Msg == WM_VSCROLL || msg.Msg == WM_MOUSEWHEEL)
			{
				if( Scrolled != null )
				{
					ScrollInfoStruct si = new ScrollInfoStruct();
					si.fMask = SIF_ALL;
					si.cbSize = Marshal.SizeOf(si);
					GetScrollInfo(msg.HWnd, 0, ref si);

					//if( msg.WParam.ToInt32() == SB_ENDSCROLL )
					//{
						ScrollEventArgs sargs = new ScrollEventArgs(
							ScrollEventType.EndScroll,
							si.nPos);
						Scrolled(this, sargs);
					//}
				}
			}
			base.WndProc(ref msg);
		}

		public ScrollingListBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
            
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

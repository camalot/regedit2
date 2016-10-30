using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Regedit2.Components {
  public class SystemImageListHost {
  
    private static SystemImageListHost _instance = null;
    private Dictionary<string, int> _systemIcons = null;
    private ImageList _smallImageList = null;
    private ImageList _largeImageList = null;


    private SystemImageListHost ( ) {
      SystemIcons = new Dictionary<string, int> ( );
      SmallSystemImageList = new SystemImageList ( SystemImageListSize.SmallIcons );
      LargeSystemImageList = new SystemImageList ( SystemImageListSize.LargeIcons );
    }

    public SystemImageList SmallSystemImageList { get; private set; }
    public SystemImageList LargeSystemImageList { get; private set; }

    public ImageList SmallImageList {
      get {
        if ( _smallImageList == null ) {
          _smallImageList = new ImageList ( );
					
          _smallImageList.ImageSize = new Size ( 16, 16 );
          _smallImageList.ColorDepth = ColorDepth.Depth32Bit;
         }
        return _smallImageList;
      }
    }

    public ImageList LargeImageList {
      get {
        if ( _largeImageList == null ) {
          _largeImageList = new ImageList ( );
          _largeImageList.ImageSize = new Size ( 32, 32 );
          _largeImageList.ColorDepth = ColorDepth.Depth32Bit;
        }
        return _largeImageList;
      }
    }

    public Dictionary<string, int> SystemIcons {
      get;
      private set;
    }

    public void AddFileTypeImage ( string ext, Image smallImage, Image largeImage ) {
      if ( SystemIcons.ContainsKey ( ext ) ) {
        SystemIcons.Remove ( ext );
      }

      SystemIcons.Add ( ext, SmallImageList.Images.Count );
      AlphaImageList.AddFromImage ( smallImage, SmallImageList );
      AlphaImageList.AddFromImage ( largeImage, LargeImageList );
    }



    #region static methods / properties
    public static SystemImageListHost Instance {
      get {
        if ( _instance == null ) {
          _instance = new SystemImageListHost ( );
        }
        return _instance;
      }
    }
    #endregion
  }
}

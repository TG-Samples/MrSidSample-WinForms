using System;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.WinForms;
using System.IO;

namespace ThinkGeo.MapSuite.Samples
{
	public partial class MainForm : Form
	{
		public MainForm ()
		{
			InitializeComponent ();
		}

		private void MainForm_Load (object sender, EventArgs e)
		{
			winformsMap1.MapUnit = GeographyUnit.DecimalDegree;

			LayerOverlay overlay = new LayerOverlay ();

			//To resolve issue that we cannot run the executable by double click it on linux, we need to find out the absolute path by reflection.
			string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
			string mrSidLayerFileName = Path.GetFullPath (Path.Combine (baseDirectory, "../../App_Data/World.sid"));
				 
			MrSidRasterLayer mrSidRasterLayer = new MrSidRasterLayer (mrSidLayerFileName);
			overlay.Layers.Add (mrSidRasterLayer);

			winformsMap1.Overlays.Add (overlay);

			mrSidRasterLayer.Open ();
			winformsMap1.CurrentExtent = mrSidRasterLayer.GetBoundingBox ();

			winformsMap1.Refresh ();
		}
	}
}
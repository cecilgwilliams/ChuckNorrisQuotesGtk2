using System;
using Gtk;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using ChuckNorris;

public partial class MainWindow: Gtk.Window
{

	private ChuckNorrisQuotes quotes = new ChuckNorrisQuotes ();

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		notebook1.Page = 0;
		image6.Pixbuf = new Gdk.Pixbuf(".\\chuck-norris.jpg");

		Label label = new Label ();
		label.Name = "Graph";
		label.LabelProp = "Graph";

		notebook1.AppendPage (getGraph (), label);

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	private OxyPlot.GtkSharp.PlotView getGraph(){
		
		var plotModel = new PlotModel {
			Title = "Chuck Norris Performance",
			Subtitle = "",
			PlotType = PlotType.Cartesian,
			Background = OxyColors.White,

		};

		plotModel.Series.Add (new FunctionSeries (Math.Log, -10, 10, 0.1) { Color = OxyColors.Green });

		var xAxis = new LinearAxis
		{
			Position = AxisPosition.Bottom,
			Title = "Years",
			MajorGridlineStyle = LineStyle.Solid,
			MinorGridlineStyle = LineStyle.None,
		};

		plotModel.Axes.Add(xAxis);

		var yAxis = new LinearAxis
		{
			Position = AxisPosition.Left,
			Title = "Kicks per Second",
			MajorGridlineStyle = LineStyle.Solid,
			MinorGridlineStyle = LineStyle.None,
		};

		plotModel.Axes.Add(yAxis);


		var plotView = new OxyPlot.GtkSharp.PlotView { Model = plotModel };
		plotView.SetSizeRequest (400, 400);
		plotView.Visible = true;
		return plotView;
	}

	protected void NextQuoteButtonClicked (object sender, EventArgs e)
	{
		
		labelQuote.Text = quotes.GetNextQuote ();
	}
}

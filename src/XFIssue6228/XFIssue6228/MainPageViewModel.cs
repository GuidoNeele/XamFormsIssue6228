using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace XFIssue6228
{
  internal class MainPageViewModel : INotifyPropertyChanged
  {
    private Stream m_pdfDocumentStream;

    /// <summary>
    /// An event to detect the change in the value of a property.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// The PDF document stream that is loaded into the instance of the PDF viewer. 
    /// </summary>
    public Stream PdfDocumentStream
    {
      get
      {
        return this.m_pdfDocumentStream;
      }
      set
      {
        this.m_pdfDocumentStream = value;
        NotifyPropertyChanged("PdfDocumentStream");
      }
    }

    /// <summary>
    /// Constructor of the view model class
    /// </summary>
    public MainPageViewModel()
    {
      //Accessing the PDF document that is added as embedded resource as stream.
      this.m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("XFIssue6228.Assets.Test.pdf");
    }

    private void NotifyPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}

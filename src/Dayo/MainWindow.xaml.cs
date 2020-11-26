using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dayo
{

 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        private readonly MainWindowViewModel mwViewModel;
        private readonly IStore store;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public MainWindow(MainWindowViewModel mwViewModel, IStore store)
        {
            InitializeComponent();
            this.mwViewModel = mwViewModel;
            this.store = store;
            DataContext = this.mwViewModel;
            
            Note note = store.ReadMemoryList();

            mwViewModel.Content = note.Content;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();

            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            store.StoreMemoryList(new Note() { Content = mwViewModel.Content });
        }

        private void MemoryList_MouseDown(object sender, MouseButtonEventArgs e)
        {  
            if (mwViewModel.Content == "")
            {
                return;
            }
            char curentChar = MemoryList.CaretIndex == mwViewModel.Content.Length ? (char)0 : mwViewModel.Content[MemoryList.CaretIndex];
            if (curentChar == '\u2610')
            {
                mwViewModel.Content = mwViewModel.Content.Substring(0, MemoryList.CaretIndex) + "\u2611" + mwViewModel.Content.Substring(MemoryList.CaretIndex + 1);
            }
            else if (curentChar == '\u2611')
            {
                mwViewModel.Content = mwViewModel.Content.Substring(0, MemoryList.CaretIndex) + "\u2610" + mwViewModel.Content.Substring(MemoryList.CaretIndex + 1);
            }
        }

        private void DraggableRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

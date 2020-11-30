using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master1
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            profileimage.Source = ImageSource.FromFile("AboutMe.jpg");
            aboutlist.ItemsSource = GetMenuList();
            var homePage = typeof(Views.AboutPage);
            Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();
            //---------------------------------------------------------------------------------------

            list.Add(new MasterMenuItems()
            {
                Text = "My Info",
                Detail = "Info",
                ImagePath = "info.png",
                TargetPage = typeof(Views.AboutPage)
            });
            //---------------------------------------------------------------------------------------

            list.Add(new MasterMenuItems()
            {
                Text = "My experience",
                Detail = "Experience",
                ImagePath = "practice.png",
                TargetPage = typeof(Views.ExperiencePage)
            });
            //---------------------------------------------------------------------------------------

            list.Add(new MasterMenuItems()
            {
                Text = "My skills",
                Detail = "Skills",
                ImagePath = "notebook.png",
                TargetPage = typeof(Views.SkillsPage)
            });
            //---------------------------------------------------------------------------------------
            list.Add(new MasterMenuItems()
            {
                Text = "My trophy",
                Detail = "Trophy",
                ImagePath = "trophy.png",
                TargetPage = typeof(Views.SkillsPage)
            });
            //---------------------------------------------------------------------------------------
            return list;
        }

        private void aboutlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}

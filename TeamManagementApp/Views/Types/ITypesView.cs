using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Members
{
    public interface ITypesView
    {
        ICommonComboBox<ProjectType, int> CmbTypes { get; set; }
        ICommonTextBox TxtTypeDetails { get; set; }
    }
}

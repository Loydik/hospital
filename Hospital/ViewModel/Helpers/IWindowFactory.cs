﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.ViewModel.Helpers
{
    public interface IWindowFactory
    {
        void CreateNewWindow(ObservableObject viewModel, Window window);
    }
}

//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Backend.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Initialize the database engine.
            //Yes. I initialize if before the app loads
            DataManager.Initialize(new System.IO.FileInfo("POS.db"));
            
            //Do winforms stuff
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Get the translated administrator account username
            string adminUserName;
            using (var helper = new TranslationHelper()) {
                adminUserName = helper.GetTranslation("create_user_admin");
            }

            if (DataManager.GetNumberOfUsers() < 1) {
                Application.Run(new Forms.Users.ModifyUserForm().WithName(adminUserName).WithPermissions(UserPermission.All));
            }
            //The person might've not created a user
            //Check for it
            if (DataManager.GetNumberOfUsers() < 1) {
                //Just give up and close
                return;
            }
            Application.Run(new Forms.Users.UserLoginForm());
        }

    }
}
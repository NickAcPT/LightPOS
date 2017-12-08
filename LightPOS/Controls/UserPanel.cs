//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls
{
    public partial class UserPanel : FlowLayoutPanel
    {
        #region Fields

        public const int ControlPadding = 8;

        #endregion

        #region Events

        /// <summary>
        /// Called to signal to subscribers that a user was clicked
        /// </summary>
        public event EventHandler<UserEventArgs> UserClick;

        /// <summary>
        /// Called to signal to subscribers that users' tiles have been created
        /// </summary>
        public event EventHandler UserTilesCreated;

        #endregion

        #region Properties

        public ColorScheme ColorScheme { get; set; } = DefaultColorSchemes.Blue;

        public int MaxTilesPerRow { get; set; } = 3;

        public int TileSize { get; set; } = 145;

        #endregion

        #region Methods

        public void SetupUsers(IList<User> usr)
        {
            Size tileSz = new Size(TileSize, TileSize);
            int numberOfColumns = Math.Min(MaxTilesPerRow, usr.Count);
            int numberOfRows = usr.Count / numberOfColumns + (usr.Count % numberOfColumns > 0 ? 1 : 0);

            this.InvokeIfRequired(() => {
                Width = ControlPadding + Math.Min(MaxTilesPerRow, numberOfColumns) * (ControlPadding + tileSz.Width);
                Height = ControlPadding + numberOfRows * (ControlPadding + tileSz.Height);
            });

            foreach (var user in usr) {
                TilePanelReborn rb = new TilePanelReborn
                {
                    Tag = user,
                    Size = tileSz,
                    Text = user.UserName,
                    Image = Properties.Resources.ic_person_white_48dp_2x,

                    CanBeHovered = true,
                    BackColor = ColorScheme.PrimaryColor,
                    ForeColor = ColorScheme.ForegroundColor,
                    Flat = true
                };

                this.InvokeIfRequired(() => Controls.Add(rb));

                rb.Click += (s, e) => {
                    rb.InvokeIfRequired(() => {
                        //Invoke click
                        OnUserClick(user);
                    });
                };
            }
            OnUserTilesCreated(EventArgs.Empty);
        }

        protected virtual void OnUserClick(User u)
        {
            EventHandler<UserEventArgs> eh = UserClick;

            eh?.Invoke(this, new UserEventArgs(u));
        }

        protected virtual void OnUserTilesCreated(EventArgs e)
        {
            EventHandler eh = UserTilesCreated;

            eh?.Invoke(this, e);
        }

        #endregion
    }
}
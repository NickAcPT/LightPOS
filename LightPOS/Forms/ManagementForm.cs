using System;
using System.Drawing;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Forms.Products;
using NickAc.LightPOS.Frontend.Forms.Users;
using static NickAc.LightPOS.Backend.Utils.GlobalStorage;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class ManagementForm : TemplateForm
    {
        public ManagementForm()
        {
            InitializeComponent();
            translationHelper1.Translate(this);
        }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        private void TilePanelReborn2_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.CanModifyUsers() || !CurrentUser.CanRemoveUsers())
                return;
            this.InvokeIfRequired(Hide);
            var final = SelectUserForm.ShowUserSelectionDialog(true);
            this.InvokeIfRequired(Show);
            if (final == null) return;
            this.InvokeIfRequired(Hide);
            new ModifyUserForm(UserAction.Action.ModifyUser).WithUser(final).RunInAnotherApplication();
            this.InvokeIfRequired(Show);
        }

        private void TilePanelReborn3_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.CanCreateUsers()) return;
            this.InvokeIfRequired(Hide);
            new ModifyUserForm().RunInAnotherApplication();
            this.InvokeIfRequired(Show);
        }

        private void TilePanelReborn1_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.CanManageProducts()) return;
            this.InvokeIfRequired(Hide);
            Extensions.RunInAnotherApplication<ModifyProductForm>(true, true);

            this.InvokeIfRequired(Show);
        }

        private void TilePanelReborn4_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.CanManageProducts()) return;
            this.InvokeIfRequired(Hide);
            Extensions.RunInAnotherApplication<ModifyCategoryForm>(true, true);
            this.InvokeIfRequired(Show);
        }
    }
}
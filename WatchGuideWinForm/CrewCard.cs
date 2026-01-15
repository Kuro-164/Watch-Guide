using System.Windows.Forms;
using WinFormsApp1.DTOs;

namespace WinFormsApp1
{
    public partial class CrewCard : UserControl
    {
        public CrewCard()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }

        public void Bind(CastDto cast)
        {
            lblName.Text = cast.Name;
            lblCharacter.Text = cast.Character;

            lblCharacter.Visible = !string.IsNullOrWhiteSpace(cast.Character);

            if (!string.IsNullOrEmpty(cast.Photo))
                picActor.LoadAsync(cast.Photo);
        }
    }
}

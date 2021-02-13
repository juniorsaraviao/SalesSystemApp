using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using VentaRealApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace VentaRealApp.Droid
{
   public class CustomEntryRenderer : EntryRenderer
   {
      public CustomEntryRenderer(Context context) : base(context)
      {

      }

      protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
      {
         base.OnElementChanged(e);
         //Control?.SetBackgroundResource( Resource.Drawable.abc_btn_borderless_material );
         if (Control != null)
         {
            var gd = new GradientDrawable();
            gd.SetColor(global::Android.Graphics.Color.Transparent);
            Control.Background = gd;
            //this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
            //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
         }
      }   
   }
}
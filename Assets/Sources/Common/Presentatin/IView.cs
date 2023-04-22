namespace Sources.Common.Presentatin
{
    public interface IView
    {
        void Show(object presenter);
        void Show();
        void Hide();
    }
}
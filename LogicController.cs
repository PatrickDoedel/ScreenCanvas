namespace ScreenCanvas
{
    public static class LogicController
    {
        private static string _UserTextInput = "";
        public static string UserTextInput
        {
            get 
            {
                GetUserTextWindow w = new GetUserTextWindow();
                _ = w.ShowDialog();
                return _UserTextInput; 
            }
            set 
            { 
                _UserTextInput = value; 
            }
        }
    }
}

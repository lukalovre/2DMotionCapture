namespace MoCap
{
    static class Controlls
    {
        public static bool Resume;
        public static bool SimilarColors;
        public static bool ClearImage;

        public static void Update()
        {
            //Play the recording
            //  Resume = Keyboard.GetState().IsKeyDown(Keys.Right);

            //Image filters
            //  SimilarColors = Keyboard.GetState().IsKeyDown(Keys.D1);
            // ClearImage = Keyboard.GetState().IsKeyDown(Keys.D2);

            ////Delete the saved nodes
            //if(Keyboard.GetState().IsKeyDown(Keys.Delete))
            //{
            //    File.Delete("nodes.txt");
            //}
        }
    }
}


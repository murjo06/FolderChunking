namespace System.IO {
    public class JSON {
        public static string[] Read(string filePath) {
            string dataFile = File.ReadAllText(filePath);
            string data = dataFile.Replace("{", "").Replace("}", "").Replace(" ", "").Replace("\n", "").Replace("\"from\":", "").Replace("\"to\":", "");
            int quoteLocation = 0;
            int i = 0;
            int fieldsIndex = 0;
            string[] fields = new string[2];
            foreach(char character in data) {
                if(character == '"') {
                    string usedString = data.Remove(quoteLocation, i - quoteLocation).Replace("\",", "");
                    fields[(MathF.Floor(fieldsIndex / 2) == 0.0) ? 1 : 0] = usedString.Substring(1, usedString.Length - 2);
                    fieldsIndex++;
                    quoteLocation = i;
                }
                i++;
            }
            return fields;
        }
    }
}
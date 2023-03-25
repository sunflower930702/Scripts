/// <summary>
///     共通メソッドをまとめたコントローラ
/// </summary>
public class CommonModel {


    /// <summary>
    ///     CSVファイルを配列にして取得
    /// </summary>
    public static List<string[]> GetCsvArray(string filePath, bool isSkipFirstLine) {

        if (filePath == null || filePath == "") {
            return new List<string[]>();
        }


        TextAsset csv = (TextAsset)Resources.Load(filePath);
        StringReader reader = new StringReader(csv.text);

        List<string[]> result = new List<string[]>();
        int i = 0;

        if (isSkipFirstLine) {
            string[] tmpStringArray = new string[]{};
            result.Insert(0, tmpStringArray);

            i++;
        }

        while(reader.Peek () > -1) {

            string tmpText = reader.ReadLine();
            string[] tmpTextArray = tmpText.Split(',');

            result.Insert(i, tmpTextArray);

            i++;
        }

        return result;
    }
}
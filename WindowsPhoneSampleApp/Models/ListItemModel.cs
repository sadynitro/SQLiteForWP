using SQLite;
using System.Collections.Generic;

namespace WindowsPhoneSampleApp.Models
{
  class ListItemModel
  {
    // SQLite接続オブジェクト
    private SQLiteConnection _db;

    // テーブルのスキーマ定義
    public class Items
    {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }
      public string UserName { get; set; }
      public string Info { get; set; }
    }

    public ListItemModel()
    {
      var dbPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
      // DBファイルのパスをセット
      _db = new SQLiteConnection(dbPath + "/WPSampleApp");
      // Itemsテーブルを削除
      _db.DropTable<Items>();
      // Itemsテーブルを作成
      _db.CreateTable<Items>();

      // ダミーデータをセットする
      SetItems("hoge hoge", "Administrator");
      SetItems("huga huga", "Developer");
    }

    public void SetItems(string userName, string info)
    {
      // ユーザー名と情報を渡してItemsテーブルに挿入
      var ret = _db.Insert(new Items() { UserName = userName, Info = info });
    }
    
    public IEnumerable<Items> GetItems()
    {
      // クエリ文を実行
      return _db.Query<Items>("select * from Items order by Id;");
    }
  }
}

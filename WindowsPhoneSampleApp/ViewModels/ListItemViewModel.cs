using System.Collections.Generic;
using WindowsPhoneSampleApp.Models;

namespace WindowsPhoneSampleApp.ViewModels
{
  class ListItemViewModel
  {
    // モデルオブジェクト
    private ListItemModel _listItemModel;

    // 画面に表示するListItemクラス
    public class Item
    {
      public int Id { get; set; }
      public string UserName { get; set; }
      public string Info { get; set; }
    }

    // 画面に表示するListItemの実体
    public IList<Item> ListItems { get; set; }

    // コンストラクタ
    public ListItemViewModel(ListItemModel listItemModel)
    {
      _listItemModel = listItemModel;
      ListItems = new List<Item>();

      // Modelのメソッドを呼び出してデータを取得し、ListItemに詰め込む
      var data = _listItemModel.GetItems();
      foreach (var d in data)
      {
        var temp = new Item();
        temp.Id = d.Id;
        temp.UserName = d.UserName;
        temp.Info = d.Info;
        ListItems.Add(temp);
      }
    }
  }
}

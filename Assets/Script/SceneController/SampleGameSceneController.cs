using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SampleGameSceneController : BaseSceneController {

	/// <summary>
	/// EventTypeはItemIdと一致させる
	/// </summary>
	public enum ItemEvnetType{
		NONE=0,
		USE_MEDICINE=1,
	}

	public enum GameEventType{
		NONE=0,
		KAIWA_TEST=1,
	}

	/// <summary>
	/// ここにイベント実行時の処理が入ってきます
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="eventId">Event identifier.</param>
	public override void ExcuteGameEvent (int eventId)
	{
		switch ((GameEventType)eventId) {
		case GameEventType.NONE:
			break;
		case GameEventType.KAIWA_TEST:
			KaiwaTest();
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// ここにアイテムイベント実行時の処理が入ってきます。
	/// </summary>
	/// <param name="itemEventType">Item event type.</param>
	/// <param name="itemId">Item identifier.</param>
	public override void ExcuteItemEvent (int itemId)
	{
		switch ((ItemEvnetType)itemId) {
		case  ItemEvnetType.USE_MEDICINE:
			UseMediaItem ((ItemEvnetType)itemId);
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// 画面切り替え時に発生するイベントトリガー
	/// </summary>
	/// <param name="gameScreen">Game screen.</param>
	public override void ExcuteScreenChangeEvent (GameScreenPresenter gameScreen)
	{
		throw new System.NotImplementedException ();
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 会話テスト用
	/// </summary>
	void KaiwaTest(){
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1&&m.id<= 2).ToList()
		);
	}

	/// <summary>
	/// 回復薬使用時のイベント
	/// </summary>
	/// <param name="item">Item.</param>
	void UseMediaItem(ItemEvnetType itemEventType){
		var item = GameManager.Instance.Player.ItemList.Where(i=>i.ItemModel.mId == (int)itemEventType).FirstOrDefault();
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id >= 1&&m.id<= 2).ToList()
		);
		GameManager.Instance.UsePlayerItem (item);
		//アイテム獲得フラグをOnにする
		SaveDataManager.Instance.SavedData.GetTestItem = true;
	}

}

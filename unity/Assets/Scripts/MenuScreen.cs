using UnityEngine;
using System.Collections;

public delegate void StartEventHandler(Character player);

public class MenuScreen : GameScreen
{
	public Character player;
	public event StartEventHandler startHandler;
	public MenuScreen() : base("background|0|0:Hall_of_Fame|506|19:player|470|429:Your_Hero|698|437:btn_start_down|694|494:btn_start_up|694|494:btn_randomize_down|477|604:btn_randomize_up|477|604:instructions|28|474:big_card|15|12:player_1|378|77:p1_sword_level|373|255:p1_shield_level|455|263:p1_attack_level_label|400|257:p1_defense_level_label|492|257:text_p1_attack_level|402|276|000000|Monaco|left|36|43|30:text_p1_kills|383|320|000000|Monaco|center|36|177|30:text_p1_defense_level|492|276|000000|Monaco|left|36|43|30:player_2|604|77:p2_sword_level|599|255:p2_shield_level|681|263:p2_attack_level_label|626|257:p2_defense_level_label|718|257:text_p2_attack_level|628|276|000000|Monaco|left|36|43|30:text_p2_kills|599|320|000000|Monaco|center|36|177|30:text_p2_defense_level|718|276|000000|Monaco|left|36|43|30:playe_3|825|77:p3_sword_level|820|255:p3_shield_level|902|263:p3_attack_level_label|847|257:p3_defense_level_label|939|257:text_p3_attack_level|849|276|000000|Monaco|left|36|43|30:text_p3_kills|825|320|000000|Monaco|center|36|177|30:text_p3_defense_level|939|276|000000|Monaco|left|36|43|30")
	{
		FSprite background = new FSprite ("main_menu");
		background.x = 512;
		background.y = 384;
		this.AddChildAtIndex (background, 0);

		this.buttons ["randomize"].SignalPress += randomizeHandler;
		this.buttons ["start"].SignalPress += startButtonHandler;

		player = new Character ();
		player.setShield (1);
		player.setSword (1);
		player.health = 100;
		player.maxHealth = 100;
		player.attack = 10;
		player.defense = 10;
		this.AddChild (player);


		player.scale = 2.0f;
		//MAGIC NUMBER
		float box_size = 160;
		float padding = (box_size-player.width)/2;

		player.x = positions ["player"].x + padding;
		player.y = positions ["player"].y - padding - player.height;
	}

	public void randomizeHandler(FButton button)
	{
		player.randomizeLook ();
	}

	public void startButtonHandler(FButton button)
	{
		if(startHandler != null)
		{
			startHandler(player);
		}
	}

	override public void willShow()
	{
		
	}

	// Use this for initialization
	override public void didShow ()
	{

	}
}


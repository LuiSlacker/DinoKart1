﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

	public static List<Game> savedGames = new List<Game>();

	//it's static so we can call it from anywhere
	public static void save(Game game) {
		SaveLoad.savedGames.Add(game);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames2.gd"); //you can call it anything you want
		bf.Serialize(file, SaveLoad.savedGames);
		file.Close();
	}   

	public static void load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames2.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames2.gd", FileMode.Open);
			SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
			file.Close();
		}
	}
}
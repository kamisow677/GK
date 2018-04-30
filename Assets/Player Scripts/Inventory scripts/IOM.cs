using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class IOM  {

	public static void save<T> (T class_to_save,string file_name) where T : class, new()
	{
		BinaryFormatter binaryFormater=new BinaryFormatter();
		FileStream file=File.Create(Application.persistentDataPath+"/"+file_name);
		binaryFormater.Serialize(file,class_to_save);
		file.Close();
	}
	public static T load<T> (string file_name) where T : class, new()
	{
		BinaryFormatter binaryFormater=new BinaryFormatter();
		FileStream file=File.Open(Application.persistentDataPath+"/"+file_name,FileMode.Open);
		T loadedClass=binaryFormater.Deserialize(file) as T;
		file.Close();
		return loadedClass;
	}
	public static bool fileExists(string filename)
	{
		return File.Exists(Application.persistentDataPath+"/"+filename);
	}
}

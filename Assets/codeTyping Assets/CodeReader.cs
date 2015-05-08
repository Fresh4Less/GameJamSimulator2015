using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CodeReader {
	
	Queue<String> words;
	List<String> blueWords;
	List<String> greenWords;

	public CodeReader()
	{
		words = new Queue<String>();
		blueWords = new List<String>();
		blueWords.Add("Exception");
		blueWords.Add("bool");
		blueWords.Add("int");
		blueWords.Add("String");
		blueWords.Add("string");
		blueWords.Add("codeReader");
		blueWords.Add("Queue<String>");
		blueWords.Add("List<String>");
		greenWords = new List<String>();
		greenWords.Add("public");
		greenWords.Add("private");	
		greenWords.Add("if");	
		greenWords.Add("else");	
		greenWords.Add("switch");	
		greenWords.Add("default");	
		greenWords.Add("case");
		greenWords.Add("return");	
		greenWords.Add("class");
		greenWords.Add("new");		
	}
	/// <summary>
	/// Loads the specified filename.
	/// Take from http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
	/// </summary>
	/// <param name="zilename">Filename.</param>
	public bool Load(string filename)
	{
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(filename, Encoding.Default);
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split(' ');
						if (entries.Length > 0)
						{
							foreach(string s in entries)
							{
								String str = s.Trim();
								if(s.Length > 0)
									words.Enqueue(str);
							}
						}
					}
				}
				while (line != null);
				
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			Console.WriteLine("{0}\n", e.Message);
			return false;
		}
	}
	/// <summary>
	/// Outputs the next word and its color to draw.
	/// </summary>
	/// <returns><c>true</c>, if read word was tryed, <c>false</c> otherwise.</returns>
	/// <param name="outStr">Out string.</param>
	/// <param name="outColor">Out color.</param>
	public bool TryReadWord(out string outStr, out Color outColor)
	{
		if(words.Count == 0)
		{
			outStr = "";
			outColor = Color.black;
			return false;
		}
		
		outStr = words.Dequeue();
		if(greenWords.Contains(outStr))
		{
			outColor = Color.green;
		}
		else if(blueWords.Contains(outStr))
		{
			outColor = Color.blue;
		}
		else
		{
			outColor = Color.black;
		}
		return true;
	}
	
}

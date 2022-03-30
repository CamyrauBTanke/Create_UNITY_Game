using System.Collections.Generic;


[System.Serializable]
public class Dialog {
	public List<Node> nodes;
}

[System.Serializable]
public class Node {
	public List<Phrase> phrases;
	public List<Answer> answers;
}

[System.Serializable]
public class Phrase {
	public string header;
	public string text;
}

[System.Serializable]
public class Answer {
	public string text;
	public int next;
}

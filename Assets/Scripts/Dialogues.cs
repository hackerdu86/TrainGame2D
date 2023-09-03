using System.Collections.Generic;

public static class Dialogues
{
    public enum DIALOGUES_INDEX
    {
        FIRST_DIALOGUE,
        DOOR_LOCKED,
        ID_FOUND,
        POOR_GUY,
        NOT_THE_RIGHT_TIME,
        NOT_THE_RIGTH_PATH
    }
    private static List<List<string>>  ALL_DIALOGUES = new List<List<string>>()
    {
        new List<string>() {"What a beautiful day to visit your brother that lives on the other side of the freaking planet!", "It's been 3 hours and we're not arrived!", "Anyways...", "I really need to pee..."},
        new List<string>() { "It's locked", "It requires a staff ID to be opened" },
        new List<string>() { "You found a staff ID" },
        new List<string>() { "Poor guy...", "I don't think I could've helped him", "I have to get out of here to not finish like him!"},
        new List<string>() {"I don't think its the right time to do that"},
        new List<string>() {"I don't think it's that way"}
    };
    public static List<string> GetDialogues(int index)
    {
        return ALL_DIALOGUES[index];
    }
}
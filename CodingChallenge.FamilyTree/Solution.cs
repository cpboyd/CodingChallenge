using System;

namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        /// <summary>
        /// Find the birth month for <paramref name="descendantName"/> given a family tree in <paramref name="person"/>
        /// </summary>
        /// <param name="person">family tree</param>
        /// <param name="descendantName">name to find within the family tree</param>
        /// <returns>the birth month as a string or an empty string if <paramref name="descendantName"/> is not found</returns>
        public string GetBirthMonth(Person person, string descendantName)
        {
            // Check to see if this person is the desired descendant
            if (person.Name == descendantName)
            {
                // TODO: Specify culture to ensure expected behavior on devices not set to en-US
                // Must make matching changes to the Test project
                return person.Birthday.ToString("MMMM");
            }

            // This shouldn't happen unless Descendants is manually set to null, since it's initialized to an empty list
            if (person.Descendants == null)
            {
                return string.Empty;
            }

            // Loop through all of this person's descendants
            foreach (var descendant in person.Descendants)
            {
                // Recursively check each descendant
                var checkChildren = GetBirthMonth(descendant, descendantName);
                if (checkChildren != string.Empty)
                {
                    return checkChildren;
                }
            }
            return string.Empty;
        }
    }
}
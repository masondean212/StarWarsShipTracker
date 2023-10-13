namespace DTOs.ApiDTOs;

public class ApiProperties
{
    private string _initialValue;
    public string name
    {
        get
        {
            return _initialValue;
        }
        set
        {
            _initialValue = value;
            setNameAndValue();
        }
    }
    public string Name { get; private set; }
    public int ModifierValue { get; private set; }
    
    private void setNameAndValue()
    {
        if (_initialValue.Contains(" "))
        {
            if (_initialValue.StartsWith("Power"))
            {
                var startingPlace = _initialValue.IndexOf("e ");
                Name = "Power";
                ModifierValue = int.Parse(_initialValue.Substring(startingPlace + 2, _initialValue.IndexOf("/") - startingPlace - 2));
            }
            else if (_initialValue.StartsWith("(Range"))
            {
                var startingPlace = _initialValue.IndexOf(" ");
                Name = "Range";
                ModifierValue = int.Parse(_initialValue.Substring(startingPlace + 1, _initialValue.IndexOf("/") - startingPlace - 1));
            }
            else
            {
                var startingPlace = _initialValue.IndexOf(" ");
                Name = _initialValue.Substring(0, startingPlace);
                ModifierValue = int.Parse(_initialValue.Substring(startingPlace + 1));
            }
        }
        else
        {
            Name = _initialValue;
            ModifierValue = 0;
        }
    }
}

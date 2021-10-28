# Enum as Dropdown list
In Most of the cases we have scenario in the development to papulate values of an enum into a SelectList or dropdown. 
If you have a list of enum and you want to papulate that in form of the dropdown or selected list this file really help you.
This file have **Generic** method to convert enum into Selected list.

## Installation
1-Copy **Compelete file of code** from blow and past this into your project.
2-Copy file in the folder Helper -> EnumHelper this file have the readymade code to start.



## ToSelectList<TEnum>()
Convert Enum to Selected List
```c#
    public static SelectList ToSelectList<TEnum>()
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }

#'TEnum'
Name Enum name you want to get in the form of a Selected list 
```

## ToSelectList<TEnum>(TEnum selectedValue)
This method will Convert Enum to Selected list with Selected Value
```C#
  public static SelectList ToSelectList<TEnum>(TEnum selectedValue)
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }

#'TEnum'
Name Enum name you want to get in the form of a Selected list
```

## ToSelectListDisplayName<TEnum>()

Some Time we want to show different text for enum in this case we have to define the decorator  **[Display(Name= "Rejected")]**

```C#
        public static SelectList ToSelectListDisplayName<TEnum>()
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = GetDisplayName(x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }

#'TEnum'
Name Enum name you want to get in the form of a Selected list 
#GetDisplayName(x)
Method Definition Available blow for further help 
```


## ToSelectListDisplayName<TEnum>()

Some Time we want to show different text for enum in this case we have to define the decorator  **[Display(Name= "Rejected")]** 
This method will show enum in the selected list with Display Name as Text

```C#
     public static SelectList ToSelectListDisplayName<TEnum>(TEnum selectedValue)
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = GetDisplayName(x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }

Name Enum name you want to get in the form of a Selected list 
#GetDisplayName(x)
Method Definition Available blow for further help 
```



## GetDisplayName(Enum enumValue)

This Method will get the name of the enum from decorater this will return the original enum in case decorater not defined for some enums
```C#
  public static string GetDisplayName(Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }

Name Enum name you want to get in the form of a Selected list 
#GetDisplayName(x)
Method Definition Available blow for further help 
```

# How to Use this 
**Examples**
```C#
ViewBag.Status = EnumSelectedListMethods.ToSelectListDisplayName<enumStatus();
```
**In Razor Page **
```HTML
<div class="row">
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
        <label>Status</label>
        <div class="form-group selecter-feild">
            <select asp-items=" ViewBag.Status" class="form-control"></select>
        </div>
    </div>
</div>

```

# Compelete file of code 
``` C#
   public static class EnumSelectedListMethods
    {
        //to selcted List
        public static SelectList ToSelectList<TEnum>()
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }
        //with Selected Value
        public static SelectList ToSelectList<TEnum>(TEnum selectedValue)
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }

        //to selcted List with dispaly Name
        public static SelectList ToSelectListDisplayName<TEnum>()
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = GetDisplayName(x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }
        //to Selected list with Selected Value and Display Name
        public static SelectList ToSelectListDisplayName<TEnum>(TEnum selectedValue)
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = GetDisplayName(x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }

        //Display Name of the enum
        public static string GetDisplayName(Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }


    }
```


## join me on Linkedin
[mawazejaz](https://www.linkedin.com/in/mawaz/)

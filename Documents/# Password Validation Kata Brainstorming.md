# Password Validation Kata Brainstorming

 Link : https://katalyst.codurance.com/password-validation

## Goal:
Iteration 1 already achieved - next is implementing Iteration 2...

Design and implement software that can adapt to different password validation rules, with TDD and focus on the OOP principles.  

Let's pretend that now we want to create another type of password validations because on our app we need different types of passwords, such as:

Validation 2:  
Have more than 6 characters  
Contains a capital letter  
Contains a lowercase  
Contains a number  

Validation 3:  
Have more than 16 characters  
Contains a capital letter  
Contains a lowercase  
Contains an underscore  

Things to practice:   
In this iteration, we should try to identify a good abstraction and try to work on OOP principles as well as on design patterns like Builder and Factory


### Thoughts:

If config for existing methods is kept in Validator, Builder could be used for creating it.
Such as: 
Boolean property to determine if we require Capital/Lowercase/Numeric/Underscore (If true, apply validation rule when validate is called)
Int property for determining character limit (if value > 0 then apply validation rule when validate is called)

This would require changing the Validate method to account for these properties, and adding a Builder to create the Validator

But, that raises a question whether a Builder is the right choice over a Factory - there's no requirement to change properties of the validator at runtime.

From investigation, it looks like builder is better for handling multiple optional parameters, as they don't need to be touched unless required. Having default values for these properties would make this valuable - as well as support for future validation rules without breaking what already exists.

Arguably, a Factory could be used in this way, where the properties are extracted from the Validator class and into a ValidatorConfig data class, which would then be used as a parameter in the Factory...
but then this raises issues on how to build the config class, and whether a class that only holds data is a code-smell or not...

Currently, my choice is to use a ValidatorBuilder.
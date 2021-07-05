# How to contribute

Thanks for wanting to make this library better. Even the little things help a lot. ❤

But befor you start, please read the [code of conduct](https://github.com/basicx-StrgV/BasicxLogger/blob/main/.github/CODE_OF_CONDUCT.md) first.

## Creating Issues

If you have somthing to say, want to ask a question, report a bug or got an idea for a feature,  
you can create a issue with one of the templates.  
There are templates for:
- Feedback
- Feature request
- Bug report
- Questions

If you think the templates dont fit the thing you want to share, you can allways create an issue without a template.

## Contributing to the code

If you find a small error or typo you can just fork the repositorie and create a pull request with your changes.  
I will look at it as soon as possible.

If you read all this an still dont know what to do or how to do it, you can allway create an issue and ask or create a pull request and wait for a response.

### Adding features or creating Extensions

If you want to add support for a file type or database or even create a new logger, read this first so you know what you need to do.

#### Informations

Here are some informations you should know befor you start:
- This library uses the dotnet core framework
- Logger classes 
  - Should be put in the BasicxLogger/source/BasicxLogger/Logger/ directory
  - Should be named like this: '[FileExtension]Logger'
  - Should use the namespace BasicxLogger
- Log file classes
  - Should be put in the BasicxLogger/source/BasicxLogger/Components/Files/ or BasicxLogger/source/ExtensionName/Components/Files directory
  - Should be named like this: '[FileExtension]LogFile'
  - Should use the namespace BasicxLogger.Files
- Database classes
  - Should be put in the BasicxLogger/source/BasicxLogger/Components/Databases/ or BasicxLogger/source/ExtensionName/Components/Databases/ directory 
  - Should be named like this: '[DatabaseName]Database'
  - Should use the namespace BasicxLogger.Databases
- Extensions need to use the BasicxLogger.Base package (https://www.nuget.org/packages/BasicxLogger.Base/)
- Code Conventions can be found below

#### Add to the main package or create a extension?

You should create an extension, when:
- The feature you want to add needs more then one third-party* dependencies
- One or more dependencies need license acceptance

You can add it directly to the library it does not need to be an extension.

*third party means packages that do not belong to BasicxLogger or are not from Microsoft

#### Getting started

To start, just simply fork this repositorie.
After that you should have a look around the code to understand how everyting works.
Remember that you can always ask questions.

After that you should have a look at the code Conventions.

## Code Conventions

For the most part we use the default [C# conventions](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md).  
It is fine if yor code is not 100% conform with them but 90-95% would be good.

In addition to that:
- Never use `var`
- You can have two empty lines if it helps readability
- Your code should not have any Errors or Warnings. No Informations is nice to have.
- Everything that is declared 'public' should have documentation commands

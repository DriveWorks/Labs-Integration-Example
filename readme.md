## DriveWorks Integration Example source code. ##

This source code has been made available to demonstrate the different ways that 3rd parties can integrate with DriveWorks using the DriveWorks API.

The example requires that you have the latest DriveWorks SDK installed and operational.

There are a number of integration points, and each one will be documented below.

### User Definable Functions. ###

The plugin contains a shared project extender that has a number of functions for pulling data FROM the 3rd party system, into DriveWorks.  

These are coded in the following file.

**IntegrationSharedExtender.vb**

This is a Shared Project Extender, rather than a Standard Project Extender, because Standard Project Extenders are specific to a single project.  Shared are accessible to all projects.

The example contains some self-explanatory functions that will report back to a project the plugin status, as well as get information such as Accounts and Contacts, Items and Bills of Materials.

These are simple examples of the type of data and data formats that can be retrieved from the 3rd party system.

Since the third party system could be communicated with via a web service, or direct API calls, the example has a built in connection manager that will retry each function a number of times.

Most of the functions that return tabular data are created to return an object.  

This is to ensure that it can return a data table when successful and a reporting string in the case of an exception.

If the call to the 3rd party fails for any reason, the example shows how error text can be returned through the function.

This error text always starts with #, contains capital letters, and is followed by an exclamation mark (!).  This result style is used by DriveWorks as an error condition when using the IsErrorString() function.

An example of this is the value returned from an exception in the EXAMPLEGETITEMS function: 

    Return "#EXAMPLE! Unable to retrieve items: " & ex.Message

Since most 3rd party systems operate on a connection basis, this example has the ability to establish a connection, and then keep hold of that connection for the duration of the process being run.

In this case the Shared Project Extender has GetConnectionManager function that will get a connectionmanager from the connections shared instance. The connection is stored against each project, so that every project and specification being run has its own connection.  This is especially important with DriveWorks Live where each user must have a separate connection to other users.

Each function is then called through the connection manager using `RunWithRetry` that will ensure 3 attempts are made to perform the function in the case of a lost connection (or any exception).  This is especially relevant if the 3rd party system is being connected to through web services where there is a risk of a dropped connection.

###Specification Tasks###

This integration has been created with a single task that will be added to the Specification toolbox in the Specification Macros section in DriveWorks Administrator, as well as on the Toolbox in the tasks for each State in Specification flow.

For more tasks, create more classes that inherit `Task`.  We recommend that these are kept in separate .vb files.

The example task is in the file ExampleCreateAccount.vb

The basics of a task is that values are passed to a task from the specification when the task is run, and then the task uses those values when running the execute method.

The values are passed to a task as flow properties.  The DriveWorks SDK help file explains the different property types, as well as the different parameters required when setting one up.

In this example, there is a mixture of string and integer parameters, with names, descriptions (shown in DriveWorks Administrator when setting up the Task) and a category (Used to group together Flow Properties in DriveWorks Administrator). 
 
The FlowPropertyInfo object can also have a type to enable specific values to be prompted to the administrator. In the given example, the mReturnConstant flow property has a type of *{StandardRuleTypes.ConstantName}*  meaning that the property will show as a list of constants.

The Execute method is inherited from Task and is where the task code goes.  This has the specification context passed in from which the project can be obtained.

In this example, we are getting a connection from the connection manager and then using the connection to perform a task.
The task can write back to the DriveWorks specification report using ctx.Report.WriteEntry at any time.

In this example, we are also writing back to a constant in the specification (through the mReturnConstant flow property).  The example checks if the DWConstant prefix has been used, and if the constant exists.  If it exists, it will write whatever result you require to the constant ready for further processing back in the rules.  If the constant does not exist, it will write to the specification report.

The actual task is in a separate class that will be discussed later, and is called through the connection manager using the `RunWithRetry` function that itself ensures 3 attempts are made to run each function.

This example shows retrieving account data from the specification as individual flow properties.  It would also be reasonable to pass through a variable category and then have the task pull variable values from that category, or pass in a pipebar delimited text string and have the task parse the string.

###Specification Events###

This example has also been created to respond to specification events.  This means that you can add code that will communicate with your 3rd Party system, for instance, after a transition has been run.  The main benefit of this is that some of these events are raise once a specification has been closed, or after a document has been registered.  You could also have a parent specification react to a child specification being closed.

The specification events are handled in this example in 2 separate files.

**SpecificationServiceHandler.vb**

The specification Service Handler will create a new specification context each time a new specification is created and pass it through to the Specification Context Handler

**SpecificationContextHandler.vb**

The specification context handler will handle all of the events raised by the specification context.  All of the current events are shown here in the code, however a full and updated listing can be found in the SDK help file.
One very useful event is the ChildContextCreated event which then creates its own context handler so that the events can be handled for all child specifications.

Do ensure that you use the exception handling shown in some of the example event handlers, and do make sure you dispose of any objects that you instantiate, especially when referencing DriveWorks objects.
The specificationContextHandler is passed an instance of integrationcore which will be covered later in this document.

One of the events, `mContext.DocumentRegistered`, shows how a document created by DriveWorks can be registered in the 3rd party system, with logging.

###Model Generation Events###

As well as specification events, DriveWorks raises events when generating 3D models in SolidWorks as well as 2D Drawings.

At any point of the model generation process, these events allow you to run 3rd party code.  This could be to retrieve new part numbers or material prices before the models are generated or to export documents to specific location after the models have been generated.  They can even be used to export a bill of materials (if the Bill of materials needs to be derived from the SolidWorks Assembly structure rather than from rules and calculations in the DriveWorks specification)

This example has three files that handle model generation events.

**GenerationServiceHandler.vb**

This object is instantiated whenever model generation begins, and its responsibility is to create a handler for each 3D model that gets generated by DriveWorks (2D Drawing are handled separately)

It also raises events whenever a batch of models is started and finished, allowing for pre and post processing of a number of component sets.

**ModelContextHandler.vb**

Each time a model is generated, a ModelContexthandler object is created.  This then contains all of the event handlers for all model generation events for that model (including its drawings).

**ModelContextHandler.vb**

The example shows each event, although a full up to date list is available in the SDK documentation.

Some of the event handlers also have some example code showing how to get the released model from the modelcontext and also how to determine if this model is a released part or an assembly.

For assembly traversal code, see the SolidWorks API.

In this example, the master file path and target file path are also captured as member variables.

    Private mMasterFileName As String
    Private mTargetFilename As String

These are set during the Prepared Event.

The model context also has an event for when a Drawing is about to be generated for that model.

The DrawingGenerationContextCreated event creates a drawing context handler which in turn handles all of the drawing generation events raised by DriveWorks.

**DrawingContextHandler.vb**

Similar to the model context handler, the Drawing context handler in this example has all of the events listed.  For a full and updated list see the DriveWorks SDK documentation.

From the drawing context, the released drawing as well as the released model objects are available.

Remember to handle all exceptions so that DriveWorks doesn’t have to.

###Settings###

Since there may be settings required (such as stored usernames and passwords, as well as possible connection strings) this integration example has a settings class that will get and set registry entries on each machine.

You could also get such information from the active specification through variables in DriveWorks but this would then not be accessible when not in a specification (i.e. when using specification events when the specification has been closed, or model generation events when models are being generated)

The Get and Set of the settings in this example are performed in a single class.

**PlugInSettings.vb**

The settings are stored relative to the DriveWorks registry entries using the inbuilt DriveWorks settings manager.

The relative path in the registry is set in the constants at the top of the class.

There are 2 encryption/decryption functions that use the Windows data protection API.

Replace these if you require a better level of encryption.
This example then has a number of settings that are stored on this object which are in turn entered on the settings form.

**PlugInSettingsForm.vb**

Once this plugin is loaded in DriveWorks (any DriveWorks Pro Module) either by installing the binaries from the plugins section of the settings screen in DriveWorks pro, or by using an installer (this example does not include an installer, but you may wish to create one), then the settings screen can be shown.

Once installed, clicking on the plugin in the list and then clicking the settings button will show the settings screen for this example. 
Adding more settings is a simple case of copying the existing ones, taking care to ensure you use the appropriate data type.

The plugin settings screen also has a test button to which you can add code to either test your connection or test the actual communication.

###Plugin Library###

The plugin example gets loaded into DriveWorks through the IntegrationPlugIn class.  This class is passed the application object when it is initialised.

**IntegrationPlugIn.vb**

The Integrationplugin class then creates or collects the services it needs through the Servicemanager property on the application.

See the DriveWorks SDK for a full list of available services.

This also uses the connections class to store the connection, but instead of creating a new connection on the connections class (which requires a project to be passed to it) it has a BaseIntegrationCore of type integrationcore (which is discussed later) that persists for the life of the application itself.


This means that multiple calls from the same application (for instance through model generation events) all use the same instance of the integrationcore, but multiple specifications (in the case of DriveWorks Live) all get their own independent connection through the connection manager.

The main plugin class also saves and loads all of the settings, as well as launches the Plugin settings form.

###Reporting###

Plugins can add information into the applications reporting (for instance the Autopilot log and the log on the settings screen.  Plugins can also write data to a specification report.

This example has a reporting class that inherits from one, and writes to the other, which then allows for common reporting throughout the plugin, whereby the reporting in the main 3rd party class is common (in this case IntegrationCore.vb).

**ISpecificationReporting.vb**

This class implements IApplicationEventService and is passed a specification report.

It then normalises the different reporting enums.

###Connections###

Connections to the 3rd party system are handled through a connectionmanager class that stores the settings and project, and can create and destroy an instance of IntegrationCore, where all of the 3rd party connection code resides.

**ConnectionManager.vb**

When ensuring a connection the connectionmanager will create a new instance of IntegrationCore and pass it the settings, project and specification report if we are in a specification.

The connection manager also has a RunWithRetry function that will run any function in IntegrationCore and if there is an exception, try again while also calling DestroyConnection giving you the change to clean up your connection before EnsureConnection is called again to give you the opportunity to re-establish your connection.

**Connections.vb**

The connections class is called as a shared instance to hold a pointer to the settings for when each connection is made, but also to call GetSharedObject  on the project to ensure that each project (or specification) has its own connection manager.

**ProjectExtensions.vb**

ProjectExtensions is used to ensure that when a project or specification is disposed, the connection manager, and therefore the instance of IntegrationCore is also disposed.  It has a ConditionalWeakTable that it uses to maintain the list of connections.

###Integration Code###

Everything covered so far has been concerned with using the DriveWorks API to handle events and integrate into projects and specifications.

The actual code that communicates with the 3rd Party system in this example is all handled in the IntegrationCore class.

**IntegrationCode.vb**

Most of the code in this class is example code that should be removed and replaced with your specific integration code.

You code could be direct connection code through your own API, web services code to call a remote service, database code to push and pull data to and from your own database, or file import export code to read and write from your own integration files.

The example code shows methods and functions that respond to events raise by DriveWorks, as well as examples of getting Item and Bill of Material data, Accounts and contacts, entry points for 3D model traversal and a method you can use for handling document registration.

The LogMessage method uses the logging service that is passed in, and that normalises the reporting.

The example also has stub methods for checking the connection status to your third party system.











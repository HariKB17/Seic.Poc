# Domain Project

The Domain project is organized into folders with various content in each (remove any you don't need or add others as seems appropriate):


## Folders

- Business - Archivers, Inserters, Retrievers, Updators, Searchers, ...
	- Interfaces - Interfaces for the classes in Business.
- Data - Any internal data used by the domain that is not an entity.
- DataAccess - Repositories and DbContexts.
	- Interfaces - Interfaces for the classes in DataAccess.
- Entities - DB Entities.
	- Configurations - EF Configurations for DB Entities.
- Resources - .resx files for text constants.
- Validators - FluentValidation validators.

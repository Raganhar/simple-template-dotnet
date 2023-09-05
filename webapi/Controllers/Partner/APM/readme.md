# Scope
Apis custom for APM domain

# Documentation requirements
Should have its own Swagger definition

Custom endpoints should have very clearly defined use cases that they are solving
- if more services need to utilize the same functionality, the endpoint should be migrated/promoted to /partner/external/*
  - aka they should NOT start calling this endpoint if they are not the original domain
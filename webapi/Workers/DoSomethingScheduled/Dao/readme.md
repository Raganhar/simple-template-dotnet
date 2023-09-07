# Scope
Handler specific dao operations
- Allow easy mocking of handler specific DAO methods
- Please dont use lazy loading

# Testing

- Public methods should be integration tested against a DB, confirming that the responses  contain the expected data
- Any usages of DAO interfaces outside of DAO integration testing and Happy path functionality testing of Handler, should be MOCKED
# Scope
Event specific input validation

# Testing

- Unit testing of validation logic

The less tests the better ! only write tests that bring value

//TODO: discuss doing "clientside" validation of message payloads

Goal: validate type constraints
- enforce stuff that should not be null are not null
- if a guid is not nullable, then an EMPTY guid is still not valid

MessageLib

autoproff.public.events
- public event definitions
- message validators
    - allow validation before send
    - allow validation on receive
    
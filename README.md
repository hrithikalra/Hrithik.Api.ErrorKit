Hrithik.Api.ErrorKit

A lightweight, opinionated API error standardization library for ASP.NET Core

Hrithik.Api.ErrorKit provides a single, frontend-friendly error contract for all API failures — validation errors, domain errors, security failures, and unexpected exceptions.

✨ Why ApiErrorKit?

Most APIs suffer from:

Inconsistent error responses

Ad-hoc exception handling

Frontend teams guessing error formats

Mixed ProblemDetails, anonymous objects, and stack traces

ApiErrorKit fixes this by enforcing one error shape everywhere.

🎯 Goals

One consistent JSON error format

Frontend-friendly (easy to map to UI)

Secure (no stack traces or internal details)

Minimal configuration

Works with Minimal APIs & MVC

Designed for real production systems

📦 Installation
dotnet add package Hrithik.Api.ErrorKit

🚀 Quick Start
1️⃣ Register services
builder.Services.AddApiErrorKit();

2️⃣ Add middleware
app.UseApiErrorKit();


⚠️ UseApiErrorKit() must be the only global error formatter.

🧾 Standard Error Response
{
  "type": "https://errors.hrithik.dev/api-error",
  "title": "Request Failed",
  "status": 400,
  "code": "VALIDATION_ERROR",
  "message": "One or more validation errors occurred.",
  "errors": {
    "email": ["Email is required"]
  },
  "traceId": "0HNJ4NEBC5DKD:00000003",
  "timestamp": "2026-02-05T13:43:09.680091Z",
  "subErrors": []
}

🧩 Core Concepts
ApiException

All client-visible errors must derive from ApiException.

throw new NotFoundException("User not found");


ApiErrorKit automatically converts this into a standardized JSON response.

Validation Errors
throw new ValidationException(new Dictionary<string, string[]>
{
    ["email"] = new[] { "Email is required" }
});


Produces a structured errors object ideal for forms.

Unknown Errors

Any unhandled or unknown exception is safely converted to:

{
  "code": "INTERNAL_ERROR",
  "status": 500,
  "message": "An unexpected error occurred."
}

🛑 Important Design Rule

ApiErrorKit formats errors.
It does NOT decide what errors clients should see.

Infrastructure or security libraries should throw their own exceptions.
Your API should translate them into ApiException at the boundary.

🔁 Translating Infrastructure Exceptions (Example)
catch (SecurityException ex)
{
    throw new InvalidSecurityHeadersException(ex.Message);
}


This keeps:

Security libraries independent

ApiErrorKit reusable

API behavior explicit

🧠 Architecture Overview
[ Infrastructure Libraries ]
   ├─ Security / Idempotency / Rate Limiting
   └─ throw infra exceptions

[ API Boundary ]
   ├─ Translate infra → ApiException
   └─ Audit / policy decisions

[ ApiErrorKit ]
   └─ Formats ApiException → JSON

🧪 Testing

ApiErrorKit is best tested via:

Integration tests

Demo API projects

Real security & validation failures

Example assertion:

response.StatusCode.Should().Be(HttpStatusCode.Conflict);
json.Should().Contain("IDEMPOTENCY_KEY_REUSE");

📌 What ApiErrorKit Does NOT Do

❌ Does not log errors

❌ Does not decide HTTP status codes

❌ Does not replace business logic

❌ Does not couple to security libraries

🔜 Roadmap

FluentValidation integration

OpenAPI / Swagger error schemas

Localization support

TypeScript client generation

Error code registry

🤝 Contributing

Contributions are welcome:

Bug fixes

Documentation improvements

Tests

Feature discussions

Please open an issue before submitting major changes.


📜 License

MIT License


## 👤 Author

**Hrithik Kalra**

.NET | API Security | Fintech Systems

📧 Email: hrithikkalra11@gmail.com

GitHub: https://github.com/hrithikalra

LinkedIn: https://www.linkedin.com/in/hrithik-kalra-b6836a246/

If you find this package useful, consider supporting its development:

- ☕ Buy Me a Coffee: https://www.buymeacoffee.com/alkylhalid9  
- ❤️ GitHub Sponsors: https://github.com/sponsors/hrithikalra

Support is entirely optional and helps sustain ongoing development and maintenance.

---
# InternshipWebAPI

**Clone the Repo and setup your connectionstring in APP settings**

**Attached to the project root is a Postman Collection, you can import and Test easily, Also note the Base url might change on your PC**

The 8 endpoints request based on the documentation
**Program** 
- POST - `/api/ProgramTemplate`
- GET - `/api/ProgramTemplate/1aa915c5-0e9c-4a41-94e0-ecde31774652`
- PUT - `/api/ProgramTemplate/1aa915c5-0e9c-4a41-94e0-ecde31774652`

**Application template**
- GET - `/api/ApplicationTemplate/1aa915c5-0e9c-4a41-94e0-ecde31774652`
- PUT - `/api/ApplicationTemplate/1aa915c5-0e9c-4a41-94e0-ecde31774652`

**Program Preview**
- GET - `/api/ProgramPreview/fc17ee1f-99ea-43b7-8d38-6dccb63f107e`

**Workflow**
- GET - `/api/Workflow/1aa915c5-0e9c-4a41-94e0-ecde31774652`
- POST - `/api/Workflow/1aa915c5-0e9c-4a41-94e0-ecde31774652`


## Keynotes 

### enums used 
```
enum QuestionType
{
    Paragraph=0,
    ShortAnswer,
    YesNo,
    Dropdown,
    MultipleChoice,
    Date,
    Number,
    FileUpload
}

enum StageType
{   
    ShortListing=0,
    VideoInterview,
    Placement
}
```

**The structure for question is unique across and its this object**

**Question** : the Question (Required:string)

**isRequired**:bool,

**datatype:** enum (QuestionType),

**additionalField** : (could be omitted if not needed, but if needed it would be a list)
**
```
    {
        "question": "Will you be willing to travel ?",
        "isRequired": true,
        "dataType": 3,
        "additionalField": [
            "yes",
            "no",
            "maybe"
        ]
    }
    or
    {
        "question": "First name ",
        "isRequired": true,
        "dataType": 3
    }
   
   Both are valid objects to send
```

**The structure for Stage in workflow screen is also shown here**
**Stage type is from the enum above so use properly**
```
{
      "name": "Video Stage",
      "stageType": 0, 
      "questions": [
        {
          "question": "what is your name",
          "isRequired": true,
          "questionType": 0
        }
      ],
      "hidden": false
    },
```

## Creating Program
- The first Screen from figma uses the **Program POST** Endpoint
**Body Example to Create Program**
```
    {
    "title": "Microsft Long Internship",
    "summary": "This program offers a unique learning experience.",
    "description": "Participants will learn various skills and techniques.",
    "benefit": [
        "you get to Learn from the world brightest minds",
        "Montly stipends"
    ],
    "criteria": "Open to individuals passionate about learning.",
    "skills": [
        "Communication",
        "Problem-solving",
        "Teamwork",
        "HTML",
        "CSS"
    ],
    "programType": "Workshop",
    "programStart": "2023-10-15T09:00:00.000Z",
    "applicationOpen": "2023-09-15T00:00:00.000Z",
    "applicationClose": "2023-10-05T23:59:59.000Z",
    "duration": "2 weeks",
    "location": "Virtual/Online",
    "minQualification": "Bachelor's degree",
    "remote": true,
    "maxApplicant": 50
    }

```


The second and third figma screen uses **Program PUT** while attaching the application data as body along side the program body, so it attaches to entities to the Program Document
**JSON Body Example**

```
{
    "title": "Microsft Summer Internship",
    "summary": "This program offers a unique learning experience.",
    "description": "Participants will learn various skills and techniques.",
    "benefit": [
        "Learn from fast paced environment",
        "Montly stipends"
    ],
    "criteria": "Open to individuals passionate about learning.",
    "skills": [
        "Communication",
        "Problem-solving",
        "Teamwork",
        "HTML",
        "CSS"
    ],
    "programType": "Workshop",
    "programStart": "2023-10-15T09:00:00.000Z",
    "applicationOpen": "2023-09-15T00:00:00.000Z",
    "applicationClose": "2023-10-05T23:59:59.000Z",
    "duration": "2 weeks",
    "location": "Virtual/Online",
    "minQualification": "Bachelor's degree",
    "remote": true,
    "maxApplicant": 50,
    "applicationTemplate": {
        "programTemplateId": "6b831005-afea-48b5-ae61-b92513aa7570",
        "questions": [
            {
                "question": "First Name",
                "isRequired": true,
                "dataType": 1
            },
            {
                "question": "Last Name",
                "isRequired": true,
                "dataType": 1
            },
            {
                "question": "Email",
                "isRequired": true,
                "dataType": 1
            },
            {
                "question": "Phone",
                "isRequired": true,
                "dataType": 1
            },
            {
                "question": "Date",
                "isRequired": false,
                "dataType": 1
            },
            {
                "question": "Will you be willing to travel for business trips occasionally",
                "isRequired": true,
                "dataType": 3,
                "additionalField": [
                    "yes",
                    "no",
                    "maybe"
                ]
            }
        ],
        "education": {
            "isRequired": true,
            "questions": [
                {
                    "question": "School name",
                    "isRequired": true,
                    "questionType": 1
                },
                {
                    "question": "Degree Obtained",
                    "isRequired": true,
                    "questionType": 1
                }
            ]
        },
        "experience": {
            "isRequired": true,
            "questions": [
                {
                    "question": "Your last company ?",
                    "isRequired": true,
                    "questionType": 1
                },
                {
                    "question": "Your role at said company ?",
                    "isRequired": true,
                    "questionType": 1
                }
            ]
        },
        "resume": {
            "isRequired": true,
            "questions": [
                {
                    "question": "Upload a Resume",
                    "isRequired": true,
                    "questionType": 1
                }
            ]
        }
    },
    "workflow": {
        "programTemplateId":"0defb82e-e323-4e56-a4c8-d4c79a447351",
        "workflows": [
            {
                "name": "Video Application",
                "stageType": 0,
                "questions": [
                    {
                        "question": "what is your name",
                        "isRequired": true,
                        "questionType": 0
                    }
                ],
                "hidden": false
            }
        ]
    }
}

```

**You can also Update Application form using its own PUT ENDPOINT**
**Body Example**
**The question property is an array so it can take as much question as the frontend can send**
```
 {
            "id": "173e9e26-5c06-44a4-a79a-2fcbb76f44c7",
            "programTitle": null,
            "programTemplateId": "792391c7-5775-4cba-aef4-6e8dfd264a1e",
            "questions": [
                {
                    "question": "First Names",
                    "isRequired": true,
                    "questionType": 0,
                    "additionalField": null
                },
                {
                    "question": "Last Name",
                    "isRequired": true,
                    "questionType": 0,
                    "additionalField": null
                },
                {
                    "question": "Email",
                    "isRequired": true,
                    "questionType": 0,
                    "additionalField": null
                },
                {
                    "question": "Phone",
                    "isRequired": true,
                    "questionType": 0,
                    "additionalField": null
                },
                {
                    "question": "Date",
                    "isRequired": false,
                    "questionType": 0,
                    "additionalField": null
                },
                {
                    "question": "Will you be willing to travel for business trips occasionally",
                    "isRequired": true,
                    "questionType": 0,
                    "additionalField": [
                        "yes",
                        "no",
                        "maybe"
                    ]
                }
            ],
            "programTemplate": null,
            "education": {
                "isRequired": true,
                "questions": [
                    {
                        "question": "School name",
                        "isRequired": true,
                        "questionType": 1,
                        "additionalField": null
                    },
                    {
                        "question": "Degree Obtained",
                        "isRequired": true,
                        "questionType": 1,
                        "additionalField": null
                    }
                ]
            },
            "experience": {
                "isRequired": true,
                "questions": [
                    {
                        "question": "Your last company ?",
                        "isRequired": true,
                        "questionType": 1,
                        "additionalField": null
                    },
                    {
                        "question": "Your role at said company ?",
                        "isRequired": true,
                        "questionType": 1,
                        "additionalField": null
                    }
                ]
            },
            "resume": {
                "isRequired": true,
                "questions": [
                    {
                        "question": "Upload a Resume",
                        "isRequired": true,
                        "questionType": 7,
                        "additionalField": null
                    }
                ]
            }
        }
```

**To Update Workflow**
**Body Example**
**The work flow attribute in the object is also an array so it can take as much stages as required**
```
{
  "programTemplateId": "fc17ee1f-99ea-43b7-8d38-6dccb63f107e",
  "workflows": [
    {
      "name": "Video Stage",
      "stageType": 0,
      "questions": [
        {
          "question": "what is your name",
          "isRequired": true,
          "questionType": 0
        }
      ],
      "hidden": false
    },
    {
      "name": "Getting to know you",
      "stageType": 1,
      "questions": [
        {
          "question": "what is your name",
          "isRequired": true,
          "questionType": 0
        }
      ],
      "hidden": false
    }
  ]
}
```
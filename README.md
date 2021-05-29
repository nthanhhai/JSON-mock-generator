# Introduction
Sample C# console application to generate JSON test data for API testing. The appliation can generate data based on 


| Field Name | Type | Limitation |
| ----------- | ----------- | ----------- |
| Id | GUID |
| Name | String | Unique for each record, Max 256 characters |
| Date | Date |
| State | Enum | New/Active/Complete |


## Parameters
- **number** - Rquired = true - Number of record to be generated
- output - Required = false - output file name to store genrated records. Default value = testdata.json
- invalid - Required = false - Accepted value: Y/N. Will generate random name more than 256 chars. Default value = N

## Example
1. To generate 1000 record

```JSON-mock-data.exe --number 1000```

2. To generate 200 record and save to TestData.json

```JSON-mock-data.exe --number 200 --output TestData.json```

3. To generate 200 record of invalid name and save to TestData.json

```JSON-mock-data.exe --number 200 --invalid Y --output TestData.json```
### Example output
```json
[
  {
    "GUID": "8d6cf6e9-5c6f-47d7-9ce2-a43301429fa9",
    "Name": "NELVSHBAXBGGGNFTARTKAYHUDVDAIEZSZZYJOLZIPXKLSRCQGURGIBKPXQRXEBRSCNGHOVEORLVDOWCLSMTONSKYOIMYTCDOFRIELVBLPCOWGHBAOFESHCFJDHSFIGUPHHXXNX",
    "Date": "1991-06-01T18:52:12.203481",
    "State": "Acitve"
  },
  {
    "GUID": "f8a15dea-91bd-47d5-ad07-14040df457ea",
    "Name": "SHCLSKZOTMCLOQXCBXPKDNNQETUFXDKWLTTSGPHYKNDYBZQDHWGFWJQETMGZQTRPCFZVWEWMPRAQKPOFCQYAWEACDPZTIIHRWNWVAVGCAUQEJZTDXBWZUQSXEWRHFCDGJJUXTTFHKVABOWTDVVWGMIWFUZRDEYXXQJUZFWKEWOOZQRIHDNMKFXT",
    "Date": "1973-02-17T05:29:47.479605",
    "State": "New"
  }
]
```

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
    "GUID": "fc0f920a-464f-4000-af0e-ea114728a546",
    "Name": "JAAVKSGFBPPUETADQUYLWKEXXLYUCROTGJCBH TSFGQSKGBMKHECFCJSKQZIXMMTSRNOMYSURUODWDXCKTNEDROIUQPIZKVSUW",
    "Date": "1993-06-15T17:30:43.3414426",
    "State": "Acitve"
  },
  {
    "GUID": "9d296288-fdce-4a99-a373-48b14e6c8228",
    "Name": "RSKNVYGXNRRKCUNEEHIVMBIOEWKFQJSRNNTMVLOAPJUCZEGJFSLUUNUPKVJZOAHEZAWPBAJTTIGCHFPZPAAXXYWASDCABOMOCPDZHQIEJSAMGSIEGJJNAJ RSKNVYGXNRRKCUNEEHIVMBIOEWKFQJSRNNTMVLOAPJUCZEGJFSLUUNUP",
    "Date": "1997-11-18T14:45:53.8936908",
    "State": "Complete"
  }
]

```

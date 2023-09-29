# abpApiDemo

use abp to rewrite a ruoyi backend

## Step 1
create an abp api template project:

> `abp new ApiDemo -u none`

## Step 2
1. replace database provider from sqlserver to mysql
2. run ruoyi db script: ry_20230223.sql

issues:
1. need to remove openiddict from project
2. merge aspnet identity with ruoyi, include user and role tables

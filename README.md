# Overview
This is a simple application that demonstrates how to get the available visuals for a given dashboard and it's sheets how to use that information to create an embeddable URL based on the context of a registered user.

# Environment Setup
* AWS credentials in your enviroment (EC2 IAM Role or AWS CLI 'aws configure')
* Your accountId set in the *const string accountId* in *form1.cs*

# Using the application
The *Namespace* and *User* fields are used during link generation and must be valid in your QuickSight configuration AND your credentials must give you the appropriate access to generate credentials.

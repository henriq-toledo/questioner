pipeline {
    agent any

    stages {
        stage('Clone') {
            steps {
                git branch: 'master',
                    url: 'https://github.com/henriq-toledo/questioner.git'
            }
        }
        
        stage('Build') {
            steps {
                script {
                    dir ('src\\Questioner\\Questioner.WebApi') {
                        bat "dotnet build"
                    }
                }
            }
        }
        
        stage('Package') {
            steps {
                script {
                    dir ('src\\Questioner\\Questioner.WebApi') {
                        bat "dotnet publish --configuration Release --runtime win81-x64 /p:EnvironmentName=Production --self-contained true --output \"${WORKSPACE}\\publish\""
                    }
                }
            }
        }
        
        stage('Publish') {
            steps {
                script {
                    
                    try {
                        bat "%systemroot%\\system32\\inetsrv\\appcmd stop apppool /apppool.name:QuestionerApiPool"
                    }
                    catch (Exception err) {
                        echo err.getMessage()
                    }
                    
                    bat "del \"C:\\inetpub\\wwwroot\\questioner-web-api\\**\" /S /Q"
                    
                    bat "xcopy \"${WORKSPACE}\\publish\\**\" \"C:/inetpub/wwwroot/questioner-web-api\" /E /Q"
                    
                    bat "%systemroot%\\system32\\inetsrv\\appcmd start apppool /apppool.name:QuestionerApiPool"
                }
            }
        }
    }
}
**#Steps to be followed to run the c# automation test on visual studio**
1. Download visual studio from-  https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=3600&passive=false
2. Once you hit above url a exe file will be downloaded now launch it and select the .Net desktop development option and click on Install (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/9989de20-b2ac-44ac-9562-2a6e77af4a77)

3. Once its installed open it and click on "create a new project" option (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/7f4d7860-bb27-449b-bdc2-7a026f7d98e6)

4. Select M-test project option and click next (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/b803a1d0-b47f-4716-96db-4594163ecc64)

5.Give project name and click next (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/38400aa3-782b-4913-aa60-29832b108c1a)

6. Select framework .net8.0 from dropdown and click create (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/022e295c-058f-41fe-a473-06a0286f0d90)

7. Now you will see following screen 
![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/c106bc35-e703-473a-ab5a-a3864bcff439)

8. Now on the left side you will see a project name ex: - TestProject1 so right click on it and select Manage Nudget package (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/cd00e33a-bf5e-4a0d-b173-fa949dbb9050)

9. Now click on browse option and search following librabries and click on them then click on install and do it for all the followig:
![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/0ddc4a9d-2bf7-419e-b283-96542c513696)

  a.Selenium.WebDriver
  b.Selenium.Support
  c.Selenium.webdriver.chromedriver
  d.DotNetSeleniumExtras.WaitHelpers

10. Now again right click on project then click on clean then click on build (As shown in below snapshot)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/8b381873-ec1d-4a96-b216-7a4c5127820b)

11. Click on File and select open folder and select the "SDSWebsiteAutomationTest.cs" file which you downloaded code from my repo.

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/d94abf03-2d83-4827-be4e-83c177a045c8)

12. Please only use "SDSWebsiteAutomationTest.cs" file and ignore other files present in my repo. (As shown below)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/630a87b3-1063-41f9-b41d-a2cb9e2720ad)

13. To run the test you need to use run option from test explorer panel, if you don't see it then click on "test" tab and select "test explorer" (As shown below)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/e2b71cb3-2064-4672-a42c-79c3c39dfd93)

14. Now you will see a "test explorer" panel on the left side now expand the test and right click on the method named as "Automation Test" (As shown below)

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/1557a9f8-51df-4e00-82fe-19178382aea3)

15. Now the test will start exectuting.


**Note: ==> Make sure to select correct file and give the same workspace name and test name as shown in below image:** 

![image](https://github.com/Shubham991-eng/C-Sharp-Automation/assets/116543835/b824c3a4-4917-49ac-a288-6e074f018701)








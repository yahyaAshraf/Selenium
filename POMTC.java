package secondautomation;

     import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

     // Import package pageObject.*

     import pageObjects.Home_Page;

     import pageObjects.LogIn_Page;

public class POMTC {

private static WebDriver driver = null;

public static void main(String[] args) {

System.setProperty("webdriver.chrome.driver","E:\\softwares\\chromedriver_win32\\chromedriver.exe");
driver = new ChromeDriver();
driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

driver.get("http://automationpractice.com/index.php");

// Use page Object library now

 Home_Page.lnk_MyAccount(driver).click();

LogIn_Page.txtbx_UserName(driver).sendKeys("krithkrith8@gmail.com");

LogIn_Page.txtbx_Password(driver).sendKeys("yohyoch1");

LogIn_Page.btn_LogIn(driver).click();

System.out.println(" Login Successfully, now it is the time to Log Off buddy.");
Home_Page.lnk_LogOut(driver).click(); 

driver.quit();
}

}
package secondautomation;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class openwebsite {
	public static void main(String[] args) {
		 System.setProperty("webdriver.chrome.driver","E:\\softwares\\chromedriver_win32\\chromedriver.exe");
			WebDriver driver = new ChromeDriver();
			driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
			driver.get("http://automationpractice.com/index.php");
			driver.findElement(By.linkText("Sign in")).click();
			driver.navigate().back();
			driver.close();

}
}

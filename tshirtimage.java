package secondautomation;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.interactions.Actions;

public class tshirtimage {
	public static void main(String[] args) throws InterruptedException {
		 System.setProperty("webdriver.chrome.driver","E:\\softwares\\chromedriver_win32\\chromedriver.exe");
			WebDriver driver = new ChromeDriver();
			driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
			driver.get("http://automationpractice.com/index.php");
			driver.findElement(By.xpath("//*[@id=\"block_top_menu\"]/ul/li[3]/a")).click();
			WebElement element = driver.findElement(By.xpath("//*[@id=\"center_column\"]/ul/li/div/div[1]/div/a[1]/img"));
			Actions act = new Actions(driver);
			act.moveToElement(element).perform();
			driver.findElement(By.xpath("//*[@id=\"center_column\"]/ul/li/div/div[1]/div/div[1]/a/i")).click();
			driver.findElement(By.xpath("//*[@id=\"category\"]/div[2]/div/div/a")).click();
			driver.findElement(By.xpath("//*[@id=\"list\"]/a/i"));
			Thread.sleep(5000);
			driver.close();
			
			

}
}

package secondautomation;

import java.util.List;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;

public class tshirtSortby {
	public static void main(String[] args) throws InterruptedException {
		 System.setProperty("webdriver.chrome.driver","E:\\softwares\\chromedriver_win32\\chromedriver.exe");
			WebDriver driver = new ChromeDriver();
			driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
			driver.get("http://automationpractice.com/index.php");
			driver.findElement(By.xpath("//*[@id=\"block_top_menu\"]/ul/li[3]/a")).click();
			
			Select oSelect = new Select(driver.findElement(By.id("selectProductSort")));
			List <WebElement> elementCount = oSelect.getOptions();
			int iSize = elementCount.size();

			for(int i =0; i<iSize ; i++){
				String sValue = elementCount.get(i).getText();
				System.out.println(sValue);
				}
			

			oSelect.selectByIndex(4);
			oSelect.selectByIndex(5);
			oSelect.selectByIndex(6);
			oSelect.selectByIndex(3);
			driver.close();

}
}
